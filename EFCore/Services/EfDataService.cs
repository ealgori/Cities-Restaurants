using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataServices;
using DTO;
using EFCore.Extensions;
using Entities;
using Infrastructure.Models;

namespace EFCore.Services
{
    public class EfDataService : IDataService
    {
        private readonly EfContext _context;
        private readonly IMapper _mapper;

        public EfDataService(EfContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<PagedList<RestaurantDto>> GetRestaurants(int? cityId, PagedOptions pagedOptions)
        {
            var restaurants = _context.Restaurants.AsQueryable();
            if (cityId.HasValue)
                restaurants = restaurants.Where(r => r.CityId == cityId);
            return restaurants.ToPagedListAsync((r) => _mapper.Map<RestaurantDto>(r), pagedOptions);
        }

        public async Task AddRestaurant(RestaurantDto restaurantDto, int cityId)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantDto);
            restaurant.CityId = cityId;
            await _context.AddAsync(restaurant);
            await _context.SaveChangesAsync();
            restaurantDto.Id = restaurant.Id;
        }
        async ValueTask<CityDto> IBaseService<CityDto>.GetById(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            return _mapper.Map<CityDto>(city);
        }

        public async Task AddCity(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
            cityDto.Id = city.Id;
        }

        async ValueTask<RestaurantDto> IBaseService<RestaurantDto>.GetById(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            return _mapper.Map<RestaurantDto>(restaurant);
        }
    }
}