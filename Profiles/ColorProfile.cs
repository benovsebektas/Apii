using AutoMapper;
using FirstApiProject.Entities.Dtos.Cars;
using FirstApiProject.Entities;
using FirstApiProject.Entities.Dtos.Colors;

namespace FirstApiProject.Profiles
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, GetColorDto>()
                .ForMember(p => p.Name, opt => opt.MapFrom(p => p.Name));
            CreateMap<CreateColorDto, Color>();
            CreateMap<UpdateColorDto, Color>();
        }
    }
}
