using CleanArchitecture.Application.UseCases.Commands.PromotionCommands.Delete;
using CleanArchitecture.Application.UseCases.Commands.UserCommands.Delete;


namespace CleanArchitecture.Application.UseCases.Commands.PromotionCommands.Update
{
    public class UpdatePromotionCommand : IRequest<UpdatePromotionResponse>
    {
        public UpdatePromotionCommand(string promotionId, UpdatePromotionRequest request)
        {
            Payload = request;
            PromotionId = promotionId;
        }
        public string PromotionId { get; set; }
        public UpdatePromotionRequest Payload { get; }
    }
}
