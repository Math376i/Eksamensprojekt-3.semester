using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class PostOrderValidator : AbstractValidator<OrderDTOs>
{
    public PostOrderValidator()
    {
        RuleFor(o => o.CustomerName).NotEmpty();
        RuleFor(o => o.PhoneNumber).NotEmpty();
        RuleFor(o => o.Email).NotEmpty();
    }
}