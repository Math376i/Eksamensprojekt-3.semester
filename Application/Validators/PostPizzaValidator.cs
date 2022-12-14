using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class PostPizzaValidator : AbstractValidator<PizzaDTOs>
{
    public PostPizzaValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Topping).NotEmpty();
        RuleFor(p => p.Email).NotEmpty();
    }
}