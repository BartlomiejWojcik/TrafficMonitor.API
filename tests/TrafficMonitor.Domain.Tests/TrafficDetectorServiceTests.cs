using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrafficMonitor.Domain.Requests.TrafficDetector;
using TrafficMonitor.Domain.Services;
using TrafficMonitor.Fixtures;
using TrafficMonitor.Infrastructure.Repositories;
using Xunit;

namespace TrafficMonitor.Domain.Tests
{
    public class TrafficDetectorServiceTests : IClassFixture<TrafficMonitorContextFactory>
    {
        private readonly TrafficDetectorRepository _trafficDetectorRepository;
        private readonly IMapper _mapper;

        public TrafficDetectorServiceTests(TrafficMonitorContextFactory trafficMonitorContextFactory)
        {
            _trafficDetectorRepository = new TrafficDetectorRepository(trafficMonitorContextFactory.ContextInstance);
            _mapper = trafficMonitorContextFactory.Mapper;
        }

        [Fact]
        public async Task gettrafficdetectors_should_return_right_data()
        {
            TrafficDetectorService sut = new TrafficDetectorService(_trafficDetectorRepository, _mapper);
            var result = await sut.GetTrafficDetectorsAsync();
            result.ShouldNotBeNull();
        }
    }
}
