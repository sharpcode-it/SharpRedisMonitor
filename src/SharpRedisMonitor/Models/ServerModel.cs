// (c) 2020 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace SharpRedisMonitor.Models
{
    public class ServerModel
    {
        public string RedisVersion { get; set; }
        public string RedisMode { get; set; }
        public string Os { get; set; }
        public string Architecture { get; set; }
        public string MultiplexingApi { get; set; }
        public string UptimeDays { get; set; }
    }
}
