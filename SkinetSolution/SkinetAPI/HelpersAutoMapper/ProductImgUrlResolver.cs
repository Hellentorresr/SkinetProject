using AutoMapper;
using Core.Entities;
using DTOs;
using Microsoft.Extensions.Configuration;

namespace SkinetAPI.HelpersAutoMapper
{
    //this class's functionality is to add the API path(https://localhost:7201/) along with the img URL
    //                                       example: "https://localhost:7201/images/products/sb-ang2.png"

    public class ProductImgUrlResolver : IValueResolver<Products, ProductToReturnDTO, string>
    {
        private readonly IConfiguration _configuration;

        public  ProductImgUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Products source, ProductToReturnDTO destination,
            string destMember, ResolutionContext context)
        {

            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _configuration["ApiURL"] + source.PictureUrl;
            }

            return null;
        }
    }
}
