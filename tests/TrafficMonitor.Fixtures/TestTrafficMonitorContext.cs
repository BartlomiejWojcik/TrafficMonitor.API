using Microsoft.EntityFrameworkCore;
using TrafficMonitor.Domain.Entities;
using TrafficMonitor.Fixtures.Extensions;
using TrafficMonitor.Infrastructure;

namespace TrafficMonitor.Fixtures
{
    public class TestTrafficMonitorContext : TrafficMonitorContext
    {
        public TestTrafficMonitorContext(DbContextOptions<TrafficMonitorContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed<TrafficDetector>("./Data/trafficDetector.json");
        }

    }
}
