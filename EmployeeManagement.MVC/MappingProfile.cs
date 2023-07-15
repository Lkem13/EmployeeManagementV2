using AutoMapper;
using EmployeeManagement.MVC.Services.Base;
using EmployeeManagement.MVC.Models;

namespace EmployeeManagement.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LocationDTO, LocationVM>().ReverseMap();
            CreateMap<CreateLocationDTO, CreateLocationVM>().ReverseMap();

            CreateMap<PositionDTO, PositionVM>().ReverseMap();
            CreateMap<CreatePositionDTO, CreatePositionVM>().ReverseMap();

            CreateMap<UserDTO, EmployeeVM>().ReverseMap();
            CreateMap<CreateUserDTO, CreateEmployeeVM>().ReverseMap();

            CreateMap<RegisterVM, RegistrationRequest>().ReverseMap();
        }
    }
}
