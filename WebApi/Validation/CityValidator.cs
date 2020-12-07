using DTO;
using FluentValidation;

namespace InverviewV1.WebApi.Validation
{
    public class CityValidator:AbstractValidator<CityDto>
    {
        public CityValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}