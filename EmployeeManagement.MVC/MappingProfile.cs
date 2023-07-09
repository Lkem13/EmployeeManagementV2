﻿using AutoMapper;
using EmployeeManagement.MVC.Services.Base;
using EmployeeManagement.MVC.Models;

namespace EmployeeManagement.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLocationDTO, CreateLocationVM>().ReverseMap();
            CreateMap<LocationDTO, LocationVM>().ReverseMap();
        }
    }
}
