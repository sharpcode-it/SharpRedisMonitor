// (c) 2020 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using Newtonsoft.Json;

namespace SharpRedisMonitor.Configuration
{
    public class RedisServer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
        public string ConnectionString { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
