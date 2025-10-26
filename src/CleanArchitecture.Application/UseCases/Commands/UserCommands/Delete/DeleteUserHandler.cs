using CleanArchitecture.Application.Authorization;
using CleanArchitecture.Domain.Interfaces.Das;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Commands.UserCommands.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
    {
        private readonly ISecurityContextAccessor _securityContextAccessor;
        private readonly IFactorUserPresetDas _factorUserPresetDas;

        public DeleteUserHandler(
            ISecurityContextAccessor securityContextAccessor,
            IFactorUserPresetDas factorUserPresetDas)
        {
            _securityContextAccessor = securityContextAccessor;
            _factorUserPresetDas = factorUserPresetDas;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userName = _securityContextAccessor.Email;
            var userPreset = await _factorUserPresetDas.GetByIdAsync(request.Payload.UserId);

            if (userPreset == null) return DeleteUserResponse.Fail($"Not found {userName} preset.");

            await _factorUserPresetDas.DeleteAsync(request.Payload.UserId);

            return DeleteUserResponse.Result();
        }
    }
}
