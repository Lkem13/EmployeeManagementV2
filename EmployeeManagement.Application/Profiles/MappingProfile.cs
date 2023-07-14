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
            CreateMap<Position, PositionDTO>().ReverseMap();
            CreateMap<Position, CreatePositionDTO>().ReverseMap();

            CreateMap<Location, LocationDTO>().ReverseMap();
            CreateMap<Location, CreateLocationDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, UserListDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
        }
    }
}
