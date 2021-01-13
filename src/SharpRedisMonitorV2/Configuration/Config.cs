// (c) 2020 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using System.Collections.Generic;

namespace SharpRedisMonitorV2.Configuration
{
    public class Config
    {
        public List<RedisServer> Servers { get; set; }
    }
}
