using System.Threading.Tasks;
using DTO;
using Entities;
using Infrastructure.Models;

namespace DataServices
{
    public interface IRestaurantService: IBaseService<RestaurantDto>
    {
        Task<PagedList<RestaurantDto>> GetRestaurants(int? cityId, PagedOptions pagedOptions);
        
    }
}