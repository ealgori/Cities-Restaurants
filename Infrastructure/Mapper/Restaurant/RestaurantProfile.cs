using AutoMapper;
using DTO;

namespace Infrastructure.Mapper.Restaurant
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Entities.Restaurant, RestaurantDto>()
                .ForMember(dest =>
                        dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                        dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

        }
    }
}