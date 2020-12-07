using System.Threading.Tasks;
using DataServices;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace InverviewV1.WebApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly ILogger<RestaurantsController> _logger;
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(ILogger<RestaurantsController> logger, IRestaurantService restaurantService)
        {
            _logger = logger;
            _restaurantService = restaurantService;
        }
        /// <summary>
        /// Retrieves a specific restaurant by id.
        /// </summary>
        /// <response code="200">Restaurant exist</response>
        /// <response code="404">Restaurant not found</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{restaurantId}", Name = "GetRestaurant")]
        public async ValueTask<IActionResult> GetById(int restaurantId)
        {
            var restaurant = await  _restaurantService.GetById(restaurantId);
            if (restaurant == null)
                return NotFound();
            return Ok(restaurant);
        }
        /// <summary>
        /// Get restaurants
        /// </summary>
        /// <remarks>You can set CityId, PageNumber and PageSize. All args optional.</remarks>
        /// <response code="200">Restaurants returned</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery]int? cityId, [FromQuery] PagedOptions pagedOptions)
        {
            var restaurants = await _restaurantService.GetRestaurants(cityId, pagedOptions);

            var metadata = new
            {
                restaurants.TotalPages,
                restaurants.PageSize,
                restaurants.CurrentPage,
                restaurants.HasNextPage,
                restaurants.HasPreviousPage
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(restaurants);
        }
    }
}