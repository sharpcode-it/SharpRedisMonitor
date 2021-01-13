// (c) 2020 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using CoreRedisStats.Configuration;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;

namespace CoreRedisStats.Services
{
    public class RedisService : IRedisService
    {
        private readonly Config _options;

        /// <summary>
        /// The Redis connections Multiplexer
        /// </summary>
        private readonly Lazy<ConnectionMultiplexer> _connection;

        /// <summary>
        /// Return a Redis connection
        /// </summary>
        /// <returns></returns>
        public ConnectionMultiplexer GetConnection() => _connection.Value;

        public RedisService(IOptions<Config> options)
        {
            _options = options.Value;
            var conn = ConfigurationOptions.Parse(_options.Servers[0].ConnectionString);
            conn.AllowAdmin = true;
            _connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(conn));
        }

        public string GetStatus()
        {
            return GetConnection().GetStatus();
        }

        public long GetOperationCount()
        {
            return GetConnection().OperationCount;
        }

        public RedisResult GetInfo(out string error)
        {
            try
            {
                error = string.Empty;
                return GetConnection().GetDatabase().Execute("info");
                //return GetConnection().GetServer(_options.Servers[0].Address, _options.Servers[0].Port).Execute("info");
            }
            catch (Exception e)
            {
                error = e.Message;
                return default;
            }
        }
    }
}
