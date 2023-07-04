using AutoMapper;
using EmployeeManagement.Application.DataTransferObject;
using EmployeeManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Location, LocationDTO>().ReverseMap();
            CreateMap<Position, PositionDTO>().ReverseMap();
        }
    }
}
