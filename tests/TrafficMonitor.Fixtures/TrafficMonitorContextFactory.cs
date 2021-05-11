using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrafficMonitor.Domain.Mappers;
using TrafficMonitor.Infrastructure;

namespace TrafficMonitor.Fixtures
{
    public class TrafficMonitorContextFactory
    {
        public readonly TestTrafficMonitorContext ContextInstance;
        public readonly IMapper Mapper;
        
        public TrafficMonitorContextFactory()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TrafficDetectorProfile());
            });

            Mapper = mapperConfig.CreateMapper();

            var contextOptions = new DbContextOptionsBuilder<TrafficMonitorContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            EnsureCreation(contextOptions);
            ContextInstance = new TestTrafficMonitorContext(contextOptions);
        }

        private void EnsureCreation(DbContextOptions<TrafficMonitorContext> contextOptions)
        {
            using var context = new TestTrafficMonitorContext(contextOptions);
            context.Database.EnsureCreated();
        }
    }
}
