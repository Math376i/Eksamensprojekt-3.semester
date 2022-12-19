using Domain;
using FluentValidation;

namespace Application.Validators;

public class PizzaValidator : AbstractValidator<Pizza>
{
    
    public PizzaValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.AlmPrice).NotNull();
        RuleFor(p => p.Fam40x40Price).NotNull();
        RuleFor(p => p.Fam50x50Price).NotNull();
        RuleFor(p => p.AlmGlutenfriPrice).NotNull();
        RuleFor(p => p.Topping).NotEmpty();
       
    }
}