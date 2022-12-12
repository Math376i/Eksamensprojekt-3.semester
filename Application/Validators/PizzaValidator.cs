using Domain;
using FluentValidation;

namespace Application.Validators;

public class PizzaValidator : AbstractValidator<Pizza>
{
    
    public PizzaValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Topping).NotEmpty();
       
    }
}