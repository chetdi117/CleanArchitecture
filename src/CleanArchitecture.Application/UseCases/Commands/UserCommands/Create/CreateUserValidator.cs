using CleanArchitecture.Application.UseCases.Commands.UserCommands.Update;


namespace CleanArchitecture.Application.UseCases.Commands.UserCommands.Create
{
    public class CreateUserValidator: AbstractValidator<UpdateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Payload)
               .NotNull()
               .NotEmpty();

            When(x => x.Payload != null, () =>
            {
                RuleFor(x => x.Payload.Email)
                    .NotNull()
                    .NotEmpty();

                RuleFor(x => x.Payload.Phone)
                    .NotNull()
                    .NotEmpty();
                RuleFor(x => x.Payload.FullName)
                   .NotNull()
                   .NotEmpty();
            });
        }
    }
}
