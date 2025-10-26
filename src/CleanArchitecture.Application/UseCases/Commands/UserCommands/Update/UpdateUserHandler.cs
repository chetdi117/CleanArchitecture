using CleanArchitecture.Domain.Entities.Factor.FactorFilters;
using CleanArchitecture.Domain.Interfaces.Das;


namespace CleanArchitecture.Application.UseCases.Commands.UserCommands.Update
{
    public class UpdateUserHandler: IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IFactorUserPresetDas _factorUserPresetDas;
        public UpdateUserHandler(IFactorUserPresetDas factorUserPresetDas)
        {
            _factorUserPresetDas = factorUserPresetDas;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userPreset = FactorUserPreset
                .New(request.Payload.Email, request.Payload.FullName, request.Payload.Phone);

            var entity = await _factorUserPresetDas.AddAsync(userPreset);

            return UpdateUserResponse.Result(entity != null ? true : false);
        }
    }
}
