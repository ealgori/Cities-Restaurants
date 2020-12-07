using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServices;
using DTO;
using Entities;
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
    public class CitiesController : ControllerBase
    {
        private readonly ILogger<CitiesController> _logger;
        private readonly ICityService _cityService;

        public CitiesController(ILogger<CitiesController> logger,  ICityService cityService)
        {
            _logger = logger;
            _cityService = cityService;
        }

        /// <summary>
        /// Retrieves a specific city by id.
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">City returned</response>
        /// <response code="404">City not found</response>
        [HttpGet]
        [Route("{cityId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async ValueTask<IActionResult> GetById(int cityId)
        {
            var city = await _cityService.GetById(cityId);
            if (city == null)
                return NotFound();
            return Ok(city);
        }
        /// <summary>
        /// Add new city
        /// </summary>
        /// <response code="201">City created</response>
        /// <response code="400">Model validation error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCity([FromBody] CityDto cityDto)
        {
            await _cityService.AddCity(cityDto);
            return CreatedAtAction(nameof(GetById), new {cityId = cityDto.Id}, cityDto);
        }
        /// <summary>
        /// Add restaurant to city.
        /// </summary>
        /// <response code="201">Restaurant added</response>
        /// <response code="400">Model validation error</response>
        [HttpPost()]
        [Route("{cityId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult>AddRestaurant(int cityId,  [FromBody] RestaurantDto restaurantDto)
        {
            var city = await _cityService.GetById(cityId);
            if (city == null) 
                return BadRequest();
            await _cityService.AddRestaurant(restaurantDto,cityId);
            return CreatedAtRoute("GetRestaurant", new {restaurantId = restaurantDto.Id},restaurantDto);
        }
    }
}