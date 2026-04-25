
using API.Models;

using AutoMapper;
using API.DTO;
namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Id,
        opt => opt.MapFrom(src => src.CategoryId))
     .ForMember(dest => dest.ImageUrl,
         opt => opt.MapFrom(src =>
             "/images/" + (src.CategoryName ?? "")
                 .Replace(" ", "")
                 .Replace("/", "")
                 .Replace("\\", "")
             + ".jpeg"));

            CreateMap<Product, ProductDto>()
               
                .ForMember(dest => dest.UnitPrice,
                    opt => opt.MapFrom(src => src.Price ?? 0))

                
                .ForMember(dest => dest.UnitsInStock,
                    opt => opt.MapFrom(src => 0));
        }
    }
}