using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrafficMonitor.Domain.Entities;

namespace TrafficMonitor.Domain.Repositories
{
    public interface ITrafficDetectorRepository : IRepository
    {
        Task<IEnumerable<TrafficDetector>> GetAsync();
        Task<TrafficDetector> GetAsync(Guid id);
        TrafficDetector Add(TrafficDetector trafficDetector);
        TrafficDetector Update(TrafficDetector trafficDetector);
    }
}
