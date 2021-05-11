using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficMonitor.Domain.Requests.TrafficDetector
{
    public class AddTrafficDetectorRequest
    {
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
