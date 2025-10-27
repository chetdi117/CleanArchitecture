using CleanArchitecture.Domain.Entities.Factor.FactorFilters;
using CleanArchitecture.Domain.Services.Das;
using MediatR; // Ensure MediatR namespace is included

namespace CleanArchitecture.Application.UseCases.Commands.PromotionCommands.Create
{
    public class CreatePromotionHandler : IRequestHandler<CreatePromotionCommand, CreatePromotionResponse>
    {
        private readonly IFactorPromotionPresetDas _factorPromotioPresetDas;

        public CreatePromotionHandler(IFactorPromotionPresetDas factorPromotioPresetDas)
        {
            _factorPromotioPresetDas = factorPromotioPresetDas;
        }

        public async Task<CreatePromotionResponse> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var userPreset = FactorPromotionPreset
                .New(request.Payload.Title, request.Payload.StartDate, request.Payload.EndDate);

            var entity = await _factorPromotioPresetDas.AddAsync(userPreset);

            return CreatePromotionResponse.Result(entity.Id);
        }
    }
}
    