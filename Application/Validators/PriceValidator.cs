using Domain;
using FluentValidation;

namespace Application.Validators;

public class PriceValidator : AbstractValidator<Price>
{

    public PriceValidator()
    {
        RuleFor(p => p.AlmPrice).GreaterThan(0);
        RuleFor(p => p.Fam40x40Price).GreaterThan(0);
        RuleFor(p => p.Fam50x50Price).GreaterThan(0);
        RuleFor(p => p.AlmGlutenfriPrice).GreaterThan(0);
    }
    
}