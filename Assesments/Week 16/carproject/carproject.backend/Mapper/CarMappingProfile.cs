using AutoMapper;
using CarManagement.Application.DTOs;

using carproject.backend.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace carproject.backend.Mappings
{
    public class CarMappingProfile : Profile
    {
        public CarMappingProfile()
        {
            // DTO → Entity
            CreateMap<CreateCarDto, Car>();

            // Entity → DTO
            CreateMap<Car, CarDto>()
                .ForMember(dest => dest.CarAge,
                    opt => opt.MapFrom(src => DateTime.Now.Year - src.Year));
        }
    }
}