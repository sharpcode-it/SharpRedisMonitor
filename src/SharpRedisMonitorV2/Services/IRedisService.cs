// (c) 2020 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using StackExchange.Redis;
using System.Collections.Generic;

namespace SharpRedisMonitorV2.Services
{
    public interface IRedisService
    {
        byte Index { get; set; }
        string Name { get; }
        string GetStatus();
        long GetOperationCount();
        RedisResult GetInfo(out string error);
        IEnumerable<RedisKey> GetKeys();
    }
}
