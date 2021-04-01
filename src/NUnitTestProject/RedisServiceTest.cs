// (c) 2020 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using NUnit.Framework;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.IO;
using SharpRedisMonitorV2.Services;
using SharpRedisMonitorV2.Configuration;

namespace NUnitTestProject
{
    [TestFixture]
    public class RedisServiceTest
    {
        private IOptions<Config> _config;
        private RedisService _service;

        [OneTimeSetUp]
        public void GlobalPrepare()
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", false)
               .Build();

            _config = Options.Create(configuration.GetSection("Config").Get<Config>());
        }

        [SetUp]
        public void PerTestPrepare()
        {
            _service = new RedisService(_config);
        }

        [Test]
        public void TestConnection()
        {
            var connection = _service.GetConnection();
            Assert.IsNotNull(connection);
        }

        [Test]
        public void TestInfo()
        {
            var info = _service.GetInfo(out var error);
            Assert.IsNotNull(info);
        }

        [Test]
        public void TestKeys()
        {
            var keys = _service.GetKeys();
            Assert.IsNotNull(keys);
        }
    }
}