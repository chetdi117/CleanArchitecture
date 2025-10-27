using CleanArchitecture.Application.UseCases.Commands.UserCommands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Commands.PromotionCommands.Create
{
    public class CreatePromotionValidator : AbstractValidator<CreatePromotionCommand>
    {
        public CreatePromotionValidator()
        {
            RuleFor(x => x.Payload)
              .NotNull()
              .NotEmpty();

            When(x => x.Payload != null, () =>
            {
                RuleFor(x => x.Payload.Title)
                    .NotNull()
                    .NotEmpty();

                RuleFor(x => x.Payload.StartDate)
                    .NotNull()
                    .NotEmpty();
                RuleFor(x => x.Payload.EndDate)
                   .NotNull()
                   .NotEmpty();
            });
        }
    }
}
