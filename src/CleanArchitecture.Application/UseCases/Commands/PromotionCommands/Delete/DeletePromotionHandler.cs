
using CleanArchitecture.Application.Authorization;
using CleanArchitecture.Domain.Services.Das;

namespace CleanArchitecture.Application.UseCases.Commands.PromotionCommands.Delete
{
    public class DeletePromotionHandler : IRequestHandler<DeletePromotionCommand, DeletePromotionResponse>
    {
        private readonly ISecurityContextAccessor _securityContextAccessor;
        private readonly IFactorPromotionPresetDas _factorPromotionPresetDas;

        public DeletePromotionHandler(
            ISecurityContextAccessor securityContextAccessor,
            IFactorPromotionPresetDas factorPromotionPresetDas)
        {
            _securityContextAccessor = securityContextAccessor;
            _factorPromotionPresetDas = factorPromotionPresetDas;
        }

        public async Task<DeletePromotionResponse> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
        {
            var userPreset = await _factorPromotionPresetDas.GetByIdAsync(request.Payload.PromotionId);

            if (userPreset == null) return DeletePromotionResponse.Fail($"Not found  preset.");

            await _factorPromotionPresetDas.DeleteAsync(request.Payload.PromotionId);

            return DeletePromotionResponse.Result();
        }
    }
}
