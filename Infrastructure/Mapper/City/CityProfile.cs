using AutoMapper;
using DTO;

namespace Infrastructure.Mapper.City
{
    public class CityProfile:Profile
    {
        public CityProfile()
        {
            CreateMap<Entities.City, CityDto>()
                .ForMember(dest =>
                        dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                        dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                ; 
        }
    }
}