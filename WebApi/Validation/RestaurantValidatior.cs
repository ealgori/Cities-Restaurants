using DTO;
using FluentValidation;

namespace InverviewV1.WebApi.Validation
{
    public class RestaurantValidatior:AbstractValidator<RestaurantDto>
    {
        public RestaurantValidatior()
        {
            RuleFor(c => c.Name).NotEmpty();
        }   
    }
}