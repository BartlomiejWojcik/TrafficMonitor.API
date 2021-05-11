using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrafficMonitor.Infrastructure;

namespace TrafficMonitor.API.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddTrafficMonitorContext (this IServiceCollection services, string connectionString)
        {
            return services.AddEntityFrameworkSqlServer()
                .AddDbContext<TrafficMonitorContext>(contextOptions =>
                {
                    contextOptions.UseSqlServer(connectionString,
                        serverOptions =>
                        {
                            serverOptions.MigrationsAssembly(typeof(Startup).Assembly.FullName);
                        }
                    );
                }
                );
        }
    }
}
