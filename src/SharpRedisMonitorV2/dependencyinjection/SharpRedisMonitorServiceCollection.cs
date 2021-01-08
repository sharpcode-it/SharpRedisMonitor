using Microsoft.Extensions.DependencyInjection;
using SharpRedisMonitorV2.Configuration;
using SharpRedisMonitorV2.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SharpRedisMonitorServiceCollection
    {
        public static IServiceCollection AddSharpRedisMonitor(this IServiceCollection services, Action<Config> config)
        {
            services.AddOptions();
            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Redis/RedisStats", "");
            });
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            //services.Configure<Config>(options => Configuration.GetSection("Config").Bind(options));
            services.Configure<Config>(config);
            services.AddSingleton<IRedisService, RedisService>();

            return services;
        }
    }
}
