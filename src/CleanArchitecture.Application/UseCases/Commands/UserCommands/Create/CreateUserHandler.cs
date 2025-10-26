using CleanArchitecture.Application.Authorization;
using CleanArchitecture.Application.UseCases.Commands.UserCommands.Update;
using CleanArchitecture.Domain.Entities.Factor.FactorFilters;
using CleanArchitecture.Domain.Interfaces.Das;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Commands.UserCommands.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IFactorUserPresetDas _factorUserPresetDas;

        public CreateUserHandler(IFactorUserPresetDas factorUserPresetDas)
        {
            _factorUserPresetDas = factorUserPresetDas;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userPreset = FactorUserPreset
                .New(request.Payload.Email, request.Payload.FullName, request.Payload.Phone);

            var entity = await _factorUserPresetDas.AddAsync(userPreset);

            return CreateUserResponse.Result(entity.Id);
        }
    }
}
