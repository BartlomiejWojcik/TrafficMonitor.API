using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficMonitor.Domain.Entities;
using TrafficMonitor.Domain.Repositories;
using TrafficMonitor.Domain.Requests.TrafficDetector;
using TrafficMonitor.Domain.Responses.TrafficDetector;

namespace TrafficMonitor.Domain.Services
{
    public class TrafficDetectorService : ITrafficDetectorService
    {
        private readonly ITrafficDetectorRepository _trafficDetectorRepository;
        private readonly IMapper _mapper;

        public TrafficDetectorService(ITrafficDetectorRepository trafficDetectorRepository, IMapper mapper)
        {
            _trafficDetectorRepository = trafficDetectorRepository;
            _mapper = mapper;
        }


        public async Task<TrafficDetectorResponse> AddTrafficDetectorAsync(AddTrafficDetectorRequest request)
        {
            var trafficDetector = _mapper.Map<TrafficDetector>(request);
            var result = _trafficDetectorRepository.Add(trafficDetector);
            await _trafficDetectorRepository.UnitOfWork.SaveChangesAsync();
            return _mapper.Map<TrafficDetectorResponse>(result);

        }

        public async Task<TrafficDetectorResponse> EditTrafficDetectorAsync(EditTrafficDetectorRequest request)
        {
            var existingRecord = await _trafficDetectorRepository.GetAsync(request.Id);
            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }
            var entity = _mapper.Map<TrafficDetector>(request);
            var result = _trafficDetectorRepository.Update(entity);
            await _trafficDetectorRepository.UnitOfWork.SaveChangesAsync();
            return _mapper.Map<TrafficDetectorResponse>(result);

        }

        public async Task<TrafficDetectorResponse> GetTrafficDetectorAsync(GetTrafficDetectorRequest request)
        {
            if (request?.Id == null) throw new ArgumentNullException();
            var entity = await _trafficDetectorRepository.GetAsync(request.Id);
            return _mapper.Map<TrafficDetectorResponse>(entity);
        }

        public async Task<IEnumerable<TrafficDetectorResponse>> GetTrafficDetectorsAsync()
        {
            var result = await _trafficDetectorRepository.GetAsync();
            return result.Select(x => _mapper.Map<TrafficDetectorResponse>(x));
        }
    }
}
