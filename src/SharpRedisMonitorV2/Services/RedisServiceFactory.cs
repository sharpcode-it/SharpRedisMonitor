using Microsoft.Extensions.Options;
using SharpRedisMonitorV2.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRedisMonitorV2.Services
{
    public class RedisServiceFactory : IRedisServiceFactory
    {
        private List<IRedisService> _redisServicesList = new List<IRedisService>();
        Config _options = null;
        public RedisServiceFactory(IOptions<Config> options)
        {
            _options = options.Value;
            
        }

        public IRedisService GetRedisService(byte index)
        {
            IRedisService serviceToReturn;

            if (index >= _options.Servers.Count)
            {
                index = 0;
            }

            if (_redisServicesList.Any(p => p.Index == index))
            {
                serviceToReturn = _redisServicesList.Where(p => p.Index == index).Single();
            }
            else
            {
                serviceToReturn = new RedisService(index, _options.Servers[index]);
                _redisServicesList.Add(serviceToReturn);
            }

            return serviceToReturn;
        } 
    }
}
