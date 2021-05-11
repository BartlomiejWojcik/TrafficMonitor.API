using System;

namespace TrafficMonitor.Domain.Entities
{
    public class TrafficDetector
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
