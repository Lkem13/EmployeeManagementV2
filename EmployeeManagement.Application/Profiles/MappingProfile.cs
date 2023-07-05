using AutoMapper;
using EmployeeManagement.Application.DataTransferObject.Location;
using EmployeeManagement.Application.DataTransferObject.Position;
using EmployeeManagement.Application.DataTransferObject.User;
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
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
