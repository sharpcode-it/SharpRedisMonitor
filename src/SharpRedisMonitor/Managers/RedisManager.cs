// (c) 2020 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using CoreRedisStats.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using static CoreRedisStats.Utility.Utility;

namespace SharpRedisMonitor.Managers
{
    public static class RedisManager
    {
        /// <summary>
        /// Build the RedisModel for dashboard presentation
        /// </summary>
        /// <param name="redisResult"></param>
        /// <returns></returns>
        public static RedisModel GetRedisModel(RedisResult redisResult)
        {            
            if (redisResult == null)
                // return an empty model
                return new RedisModel();

            var dictionary = redisResult.ToCustomDictionary();

            // build the ServerModel
            var serverModel = new ServerModel()
            {
                RedisVersion = dictionary["redis_version"],
                RedisMode = dictionary["redis_mode"],
                Os = dictionary["os"],
                Architecture = dictionary["arch_bits"],
                MultiplexingApi = dictionary["multiplexing_api"],
                UptimeDays = dictionary["uptime_in_days"]
            };

            // build the ClientsModel
            var clientsModel = new ClientsModel()
            {
                ConnectedClients = dictionary["connected_clients"]
            };

            // build the MemoryModel
            var memoryModel = new MemoryModel()
            {
                UsedMemory = GetPercentage(dictionary["used_memory_dataset_perc"], true)
            };

            // build the CPU model
            var cpuModel = new CpuModel()
            {
                ServerLoad = GetPercentage(dictionary["server_load"])
            };

            // build the KeyspaceModel
            var keyspaceModel = new KeyspaceModel()
            {
                Hits = dictionary["keyspace_hits"],
                Misses = dictionary["keyspace_misses"],
                Expired = dictionary["expired_keys"]
            };

            // build the CommandModel
            var commandModel = new CommandModel()
            {
                OperationPerSec = Convert.ToInt32(dictionary["instantaneous_ops_per_sec"]),
                BytesReceivedPerSec = Convert.ToInt32(dictionary["bytes_received_per_sec"])
            };

            var redisStatsModel = new RedisModel
            {
                ServerModel = serverModel,
                ClientsModel = clientsModel,
                MemoryModel = memoryModel,
                CpuModel = cpuModel,
                KeyspaceModel = keyspaceModel,
                CommandModel = commandModel
            };

            return redisStatsModel;
        }

        /// <summary>
        /// Return a dictionary with RedisResult key-value
        /// </summary>
        /// <param name="redisResult"></param>
        /// <returns></returns>
        private static Dictionary<string, string> ToCustomDictionary(this RedisResult redisResult)
        {
            var info = redisResult.ToString();
            var dictionary = info?.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(part => part.Contains(':'))
                .Select(part => part.Split(':'))
                .ToDictionary(split => split[0], split => split[1]);
            return dictionary;
        }
    }
}
