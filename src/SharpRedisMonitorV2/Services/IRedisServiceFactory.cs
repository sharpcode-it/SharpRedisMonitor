using System;
using System.Collections.Generic;
using System.Text;

namespace SharpRedisMonitorV2.Services
{
    public interface IRedisServiceFactory
    {
        IRedisService GetRedisService(byte index);
    }
}
