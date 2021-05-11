using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrafficMonitor.Domain.Requests.TrafficDetector;
using TrafficMonitor.Domain.Services;

namespace TrafficMonitor.API.Controllers
{
    [Route("api/trafficDetectors")]
    [ApiController]
    public class TrafficDetectorController : ControllerBase
    {
        private readonly ITrafficDetectorService _trafficDetectorService;

        public TrafficDetectorController(ITrafficDetectorService trafficDetectorService)
        {
            _trafficDetectorService = trafficDetectorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _trafficDetectorService.GetTrafficDetectorsAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _trafficDetectorService.GetTrafficDetectorAsync(new GetTrafficDetectorRequest { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddTrafficDetectorRequest request)
        {
            var result = await _trafficDetectorService.AddTrafficDetectorAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, EditTrafficDetectorRequest request)
        {
            request.Id = id;
            var result = await _trafficDetectorService.EditTrafficDetectorAsync(request);
            return Ok(result);
        }

    }
}
