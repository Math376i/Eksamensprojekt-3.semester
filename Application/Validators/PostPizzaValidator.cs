using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class PostPizzaValidator : AbstractValidator<PizzaDTOs>
{
    public PostPizzaValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.AlmPrice).GreaterThan(0);
        RuleFor(p => p.Fam40x40Price).GreaterThan(0);
        RuleFor(p => p.Fam50x50Price).GreaterThan(0);
        RuleFor(p => p.AlmGlutenfriPrice).GreaterThan(0);
        RuleFor(p => p.Topping).NotEmpty();
    }
}