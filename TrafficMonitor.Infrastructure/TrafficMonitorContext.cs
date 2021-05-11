using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TrafficMonitor.Domain.Entities;
using TrafficMonitor.Domain.Repositories;
using TrafficMonitor.Infrastructure.SchemaDefinitions;

namespace TrafficMonitor.Infrastructure
{
    public class TrafficMonitorContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "traffic_monitor";
        public DbSet<TrafficDetector> TrafficDetectors { get; set; }

        public TrafficMonitorContext(DbContextOptions<TrafficMonitorContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TrafficDetectorEntitySchemaDefinition());
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
