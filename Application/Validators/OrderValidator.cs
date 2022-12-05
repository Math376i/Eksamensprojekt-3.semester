using Domain;
using FluentValidation;

namespace Application.Validators;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(o => o.Name).NotEmpty();
        RuleFor(o => o.PhoneNumber).NotEmpty();
        RuleFor(o => o.Email).NotEmpty();
    }
}