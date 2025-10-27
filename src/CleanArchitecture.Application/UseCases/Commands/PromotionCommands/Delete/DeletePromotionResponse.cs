using CleanArchitecture.Application.Models;

namespace CleanArchitecture.Application.UseCases.Commands.PromotionCommands.Delete
{
    public class DeletePromotionResponse : ErrorResponse
    {
        public static DeletePromotionResponse Result() => new DeletePromotionResponse { Success = true };

        public static DeletePromotionResponse Fail(string message = "") => new DeletePromotionResponse { Success = false, Message = message };
    }
}
