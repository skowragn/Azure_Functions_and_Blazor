using CarsManager.Application.DTO.Request;
using FluentValidation;

namespace CarsManager.Application.Validators;

public class CarBookedItemRequestValidator : AbstractValidator<CarBookedItemRequestDto>
{
    public CarBookedItemRequestValidator()
    {
        RuleFor(x => x.UserId).NotNull();
        RuleFor(x => x.Car).NotNull();
    }
}
