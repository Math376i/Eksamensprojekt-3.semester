using Domain;
using FluentValidation;

namespace Application.Validators;

public class PizzaValidator : AbstractValidator<PizzaValidator>
{
   
    public Pizza Topping { get; set; }

    public int Price { get; set; }

    public Pizza Name { get; set; }

    public Pizza Validate(Pizza pizza)
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(p => p.Topping).NotEmpty();
        return pizza;
    }
}