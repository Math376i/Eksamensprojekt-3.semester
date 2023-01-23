using Domain;
using FluentValidation;

namespace Application.Validators;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(o => o.Password).NotEmpty();
        RuleFor(o => o.Email).NotEmpty();
    }
}