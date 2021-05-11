using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficMonitor.Domain.Entities;
using TrafficMonitor.Domain.Repositories;

namespace TrafficMonitor.Infrastructure.Repositories
{
    public class TrafficDetectorRepository : ITrafficDetectorRepository
    {
        private readonly TrafficMonitorContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public TrafficDetectorRepository(TrafficMonitorContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TrafficDetector Add(TrafficDetector trafficDetector)
        {
            return _context
                .TrafficDetectors
                .Add(trafficDetector)
                .Entity;
        }

        public async Task<IEnumerable<TrafficDetector>> GetAsync()
        {
            return await _context
                .TrafficDetectors
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TrafficDetector> GetAsync(Guid id)
        {
            var trafficDetector = await _context
                .TrafficDetectors
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return trafficDetector;
        }

        public TrafficDetector Update(TrafficDetector trafficDetector)
        {
            _context.Entry(trafficDetector).State = EntityState.Modified;
            return trafficDetector;
        }
    }
}
