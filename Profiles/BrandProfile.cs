using AutoMapper;
using FirstApiProject.Entities;
using FirstApiProject.Entities.Dtos.Brands;

namespace FirstApiProject.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, GetBrandDto>()
                .ForMember(p => p.Name, opt => opt.MapFrom(p => p.Name));
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<UpdateBrandDto, Brand>();
        }
    }
}
