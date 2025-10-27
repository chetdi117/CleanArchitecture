using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.UseCases.Commands.UserCommands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Commands.PromotionCommands.Create
{
    public class CreatePromotionResponse  : ErrorResponse
    {
        public string PromotioId { get; set; }
        public static CreatePromotionResponse Result(string promotioId)
            => new CreatePromotionResponse
            {
                PromotioId = promotioId
            };
        public static CreatePromotionResponse Fail(string message = "") => new CreatePromotionResponse { Success = false, Message = message };
    }
}
