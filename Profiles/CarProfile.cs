using AutoMapper;
using FirstApiProject.Entities.Dtos.Brands;
using FirstApiProject.Entities;
using FirstApiProject.Entities.Dtos.Cars;

namespace FirstApiProject.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, GetCarDto>()
                .ForMember(p => p.Description, opt => opt.MapFrom(p => p.Description));
            CreateMap<CreateCarDto, Car>();
            CreateMap<UpdateCarDto, Car>();
        }
    }
}
