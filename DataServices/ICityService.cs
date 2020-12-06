using System.Threading.Tasks;
using DTO;
using Entities;

namespace DataServices
{
    public interface ICityService: IBaseService<CityDto>
    {
        Task AddCity(CityDto city);
        Task AddRestaurant(RestaurantDto restaurant, int cityId);
    }
}