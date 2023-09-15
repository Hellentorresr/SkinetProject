using AutoMapper;
using Core.Entities;
using DTOs;

namespace SkinetAPI.HelpersAutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        { 
            CreateMap<Products, ProductToReturnDTO>();
        }
    }
}
