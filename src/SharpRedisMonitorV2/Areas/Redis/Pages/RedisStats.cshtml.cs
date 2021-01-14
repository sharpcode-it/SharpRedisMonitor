// (c) 2020 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using SharpRedisMonitorV2.Configuration;
using SharpRedisMonitorV2.Managers;
using SharpRedisMonitorV2.Models;
using SharpRedisMonitorV2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace CoreRedisStats.Pages
{
    public class RedisStatsModel : PageModel
    {
        
        private readonly IRedisServiceFactory _redisServiceFactory;
        private readonly Config _options;

        public RedisStatsModel(IOptions<Config> options, 
            IRedisServiceFactory redisServicefactory)
        {
            _options = options.Value;
            _redisServiceFactory = redisServicefactory;            
        }

        [FromQuery(Name = "serverIndex")]
        public string serverIndex { get; set; }

        public IRedisService MyRedisService => _redisServiceFactory.GetRedisService(GetCurrentIndex());

        [BindProperty] 
        public RedisModel Input { get; set; }

        public string DashboadName { get => MyRedisService?.Name; }

        public void OnGet()
        {
            var info = MyRedisService.GetInfo(out var error);
            var input = RedisManager.GetRedisModel(info);
            input.Servers = _options.Servers;
            input.Message = error;
            Input = input;
        }

        public JsonResult OnPostUpdateCommands()
        {
            var info = MyRedisService.GetInfo(out var error);
            var stats = RedisManager.GetRedisModel(info);
            return new JsonResult(stats);
        }

        public byte GetCurrentIndex()
        {
            byte idx = 0;
            
            if (!byte.TryParse(serverIndex, out idx))
            {
                idx = 0;
            }
            
            return idx;
        }

    }
}