using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Commands.UserCommands.Update
{
    public class UpdateUserValidator: AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Payload)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty();

            When(x => x.Payload != null, () =>
            {
                RuleFor(x => x.Payload.FullName)
                    .NotNull()
                    .NotEmpty();

                RuleFor(x => x.Payload.Email)
                    .NotNull()
                    .NotEmpty();

                RuleFor(x => x.Payload.Phone)
                   .NotNull()
                   .NotEmpty();
            });
        }
    }
}
