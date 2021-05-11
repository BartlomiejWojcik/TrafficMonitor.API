using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrafficMonitor.Domain.Requests.TrafficDetector;
using TrafficMonitor.Domain.Responses.TrafficDetector;

namespace TrafficMonitor.Domain.Services
{
    public interface ITrafficDetectorService
    {
        Task<IEnumerable<TrafficDetectorResponse>> GetTrafficDetectorsAsync();
        Task<TrafficDetectorResponse> GetTrafficDetectorAsync(GetTrafficDetectorRequest request);
        Task<TrafficDetectorResponse> AddTrafficDetectorAsync(AddTrafficDetectorRequest request);
        Task<TrafficDetectorResponse> EditTrafficDetectorAsync(EditTrafficDetectorRequest request);
    }
}
