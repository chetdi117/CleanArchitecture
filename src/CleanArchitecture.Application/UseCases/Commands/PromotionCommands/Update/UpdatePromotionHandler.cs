using CleanArchitecture.Domain.Entities.Factor.FactorFilters;
using CleanArchitecture.Domain.Services.Das;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Commands.PromotionCommands.Update
{
    public class UpdatePromotionHandler : IRequestHandler<UpdatePromotionCommand, UpdatePromotionResponse>
    {
        private readonly IFactorPromotionPresetDas _factorPromotionPresetDas;
        public UpdatePromotionHandler(IFactorPromotionPresetDas factorPromotionPresetDas)
        {
            _factorPromotionPresetDas = factorPromotionPresetDas;
        }

        public async Task<UpdatePromotionResponse> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotionPreset = FactorPromotionPreset
                .New(request.Payload.Title, request.Payload.StartDate, request.Payload.EndDate);

            var entity = await _factorPromotionPresetDas.AddAsync(promotionPreset);

            return UpdatePromotionResponse.Result(entity != null ? true : false);
        }
    }
}
