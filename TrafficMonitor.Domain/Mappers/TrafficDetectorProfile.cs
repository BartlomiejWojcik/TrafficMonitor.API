using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TrafficMonitor.Domain.Entities;
using TrafficMonitor.Domain.Requests.TrafficDetector;
using TrafficMonitor.Domain.Responses.TrafficDetector;

namespace TrafficMonitor.Domain.Mappers
{
    public class TrafficDetectorProfile : Profile
    {
        public TrafficDetectorProfile()
        {
            CreateMap<TrafficDetectorResponse, TrafficDetector>().ReverseMap();
            CreateMap<AddTrafficDetectorRequest, TrafficDetector>().ReverseMap();
            CreateMap<EditTrafficDetectorRequest, TrafficDetector>().ReverseMap();
            CreateMap<GetTrafficDetectorRequest, TrafficDetector>().ReverseMap();
        }
    }
}
