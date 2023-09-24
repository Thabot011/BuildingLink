using AutoMapper;
using Contract;
using Domain.Entites;

namespace Service.MapperProfile
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<DriverDto, Driver>().ReverseMap();
            CreateMap<CreateDriverDto, Driver>();
            CreateMap<UpdateDriverDto, Driver>();
        }
    }
}
