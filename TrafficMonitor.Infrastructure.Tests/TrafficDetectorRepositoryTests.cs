using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using TrafficMonitor.Domain.Entities;
using TrafficMonitor.Fixtures;
using TrafficMonitor.Infrastructure.Repositories;
using Xunit;

namespace TrafficMonitor.Infrastructure.Tests
{
    public class TrafficDetectorRepositoryTests : IClassFixture<TrafficMonitorContextFactory>
    {
        private readonly TrafficDetectorRepository _repo;
        private readonly TestTrafficMonitorContext _context;

        public TrafficDetectorRepositoryTests(TrafficMonitorContextFactory trafficMonitorContextFactory)
        {
            _context = trafficMonitorContextFactory.ContextInstance;
            _repo = new TrafficDetectorRepository(_context);
        }

        [Fact]
        public async Task should_get_data()
        {
            var options = new DbContextOptionsBuilder<TrafficMonitorContext>()
                .UseInMemoryDatabase(databaseName: "should_get_data")
                .Options;

            var result = await _repo.GetAsync();

            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task should_returns_null_with_id_not_present()
        {
            var options = new DbContextOptionsBuilder<TrafficMonitorContext>()
                .UseInMemoryDatabase(databaseName: "should_returns_null_with_id_not_present")
                .Options;

            var result = await _repo.GetAsync(Guid.NewGuid());

            result.ShouldBeNull();
        }

        [Theory]
        [InlineData("f8de7cdc-c94c-4f94-9577-9613087e00b5")]
        public async Task should_return_record_by_id(string guid)
        {
            var options = new DbContextOptionsBuilder<TrafficMonitorContext>()
                .UseInMemoryDatabase(databaseName: "should_return_record_by_id")
                .Options;

            var result = await _repo.GetAsync(new Guid(guid));

            result.Id.ShouldBe(new Guid(guid));
        }

        [Fact]
        public async Task should_add_new_item()
        {
            var testTrafficDetector = new TrafficDetector
            {
                Name = "Zakrzowek",
                Latitude = 50.080852F,
                Longitude = 19.950825F
            };

            _repo.Add(testTrafficDetector);
            await _repo.UnitOfWork.SaveEntitiesAsync();

            await _context.TrafficDetectors.FirstOrDefaultAsync(_ => _.Id == testTrafficDetector.Id).ShouldNotBeNull();
        }

        [Fact]
        public async Task should_update_traffic_detector()
        {
            var testTrafficDetector = new TrafficDetector
            {
                Id = new Guid("f8de7cdc-c94c-4f94-9577-9613087e00b5"),
                Name = "Zakrzowek",
                Latitude = 50.080852F,
                Longitude = 19.950825F
            };

            _repo.Update(testTrafficDetector);

            await _repo.UnitOfWork.SaveEntitiesAsync();

            _context.TrafficDetectors.FirstOrDefaultAsync(x => x.Id == testTrafficDetector.Id)?.Result.Name.ShouldBe("Zakrzowek");
        }
    }
}
