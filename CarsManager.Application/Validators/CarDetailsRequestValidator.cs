using CarsManager.Application.DTO.Request;
using FluentValidation;

namespace CarsManager.Application.Validators;

public class CarDetailsRequestValidator : AbstractValidator<CarDetailsRequestDto>
{
    public CarDetailsRequestValidator()
    {
        RuleFor(x => x.Name).NotNull();
    }
}
