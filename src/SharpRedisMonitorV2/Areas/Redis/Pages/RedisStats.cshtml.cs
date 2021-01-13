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
        private readonly IRedisService _redisAccess;
        private readonly Config _options;

        public RedisStatsModel(IOptions<Config> options, IRedisService redisAccess)
        {
            _options = options.Value;
            _redisAccess = redisAccess;
        }

        [BindProperty] 
        public RedisModel Input { get; set; }

        public void OnGet()
        {
            
            var info = _redisAccess.GetInfo(out var error);
            var input = RedisManager.GetRedisModel(info);
            input.Servers = _options.Servers;
            input.Message = error;
            Input = input;
        }

        public JsonResult OnPostUpdateCommands()
        {
            var info = _redisAccess.GetInfo(out var error);
            var stats = RedisManager.GetRedisModel(info);
            return new JsonResult(stats);
        }
    }
}