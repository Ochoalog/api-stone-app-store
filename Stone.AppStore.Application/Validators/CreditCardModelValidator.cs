using FluentValidation;
using Stone.AppStore.Application.Models;
using System;

namespace Stone.AppStore.Application.Validators
{
    public class CreditCardModelValidator : AbstractValidator<CreditCardModel>
    {
        public CreditCardModelValidator()
        {
            RuleFor(x => x.ValidateTime)
                .InclusiveBetween(DateTime.Now, DateTime.Now.AddYears(150).Date)
                .WithMessage("The validate time must not be in the past and can not to be longer than 150 yearsin the future");
        }
    }
}
