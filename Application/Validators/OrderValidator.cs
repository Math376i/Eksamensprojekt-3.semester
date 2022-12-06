using Domain;
using FluentValidation;

namespace Application.Validators;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(o => o.CustomerName).NotEmpty();
        RuleFor(o => o.PhoneNumber).NotEmpty();
        RuleFor(o => o.Email).NotEmpty();
    }
}