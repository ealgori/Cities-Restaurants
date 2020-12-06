using AutoMapper;
using Infrastructure.Mapper.City;
using Infrastructure.Mapper.Restaurant;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static  class RegisterServices
    {
        public static void RegisterMapper(this IServiceCollection collection)
        {
            collection.AddAutoMapper(typeof(CityProfile), typeof(RestaurantProfile));
        }
    }
}