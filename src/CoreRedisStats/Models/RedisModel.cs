// (c) 2020 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using System.Collections.Generic;
using CoreRedisStats.Configuration;

namespace CoreRedisStats.Models
{
    public sealed class RedisModel
    {
        public List<RedisServer> Servers { get; set; }
        public ServerModel ServerModel { get; set; }
        public ClientsModel ClientsModel { get; set; }
        public MemoryModel MemoryModel { get; set; }
        public CpuModel CpuModel { get; set; }
        public KeyspaceModel KeyspaceModel { get; set; }
        public CommandModel CommandModel { get; set; }
        public string Message { get; set; }

        public RedisModel()
        {
            Servers = new List<RedisServer>();
            ServerModel = new ServerModel();
            ClientsModel = new ClientsModel();
            MemoryModel = new MemoryModel();
            CpuModel = new CpuModel();
            KeyspaceModel = new KeyspaceModel();
            CommandModel = new CommandModel();
        }
    }
}
