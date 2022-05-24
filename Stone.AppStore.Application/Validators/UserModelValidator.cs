using FluentValidation;
using Stone.AppStore.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.AppStore.Application.Validators
{
    public class UserModelValidator : AbstractValidator<UserModel>
    {
        public UserModelValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("The first name must be at least 2 character long");

            RuleFor(x => x.Name)
                .MinimumLength(2).
                WithMessage("The first name must be at least 2 character long");

            RuleFor(x => x.BirthDate)
                .InclusiveBetween(DateTime.Now.AddYears(-150).Date, DateTime.Now)
                .WithMessage("The birthday must not be longer ago than 150 years and can not be in the future");
        }
    }
}
