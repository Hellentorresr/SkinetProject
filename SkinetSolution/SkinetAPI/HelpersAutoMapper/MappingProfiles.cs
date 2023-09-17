using AutoMapper;
using Core.Entities;
using DTOs;

namespace SkinetAPI.HelpersAutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        { 
            CreateMap<Products, ProductToReturnDTO>().
                ForMember(dto => dto.ProductBrand, opc => opc.MapFrom(source => source.ProductBrand.Name)).
                ForMember(dto => dto.ProductType, opc => opc.MapFrom(source => source.ProductType.Name)).
                ForMember(d => d.PictureUrl, o => o.MapFrom<ProductImgUrlResolver>());
        }
    }
}
