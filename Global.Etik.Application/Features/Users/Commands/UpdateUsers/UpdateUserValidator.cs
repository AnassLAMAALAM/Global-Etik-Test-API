using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Etik.Application.Features.Users.Commands.UpdateUsers
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is not Null.");
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is not Null.");
            RuleFor(c => c.Email)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull().WithMessage("{PropertyName} is not Null.");
            RuleFor(c => c.Birthday)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull().WithMessage("{PropertyName} is not Null.");
            RuleFor(c => c.Status)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull().WithMessage("{PropertyName} is not Null.");
            RuleFor(c => c.Password)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull().WithMessage("{PropertyName} is not Null.");

        }
    }
}
