using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficMonitor.Domain.Responses.TrafficDetector
{
    public class TrafficDetectorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
