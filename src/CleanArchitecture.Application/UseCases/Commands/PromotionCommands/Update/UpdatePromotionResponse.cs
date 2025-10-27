using CleanArchitecture.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Commands.PromotionCommands.Update
{
    public class UpdatePromotionResponse : ErrorResponse
    {
        public bool Data { get; set; }
        public static UpdatePromotionResponse Result(bool data)
            => new UpdatePromotionResponse
            {
                Data = data
            };
        public static UpdatePromotionResponse Fail(string message = "") => new UpdatePromotionResponse { Success = false, Message = message };
    }
}
