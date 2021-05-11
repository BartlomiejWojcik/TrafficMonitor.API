using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrafficMonitor.Domain.Services;

namespace TrafficMonitor.API.Extensions
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITrafficDetectorService, TrafficDetectorService>();
            return services;
        }
    }
}
