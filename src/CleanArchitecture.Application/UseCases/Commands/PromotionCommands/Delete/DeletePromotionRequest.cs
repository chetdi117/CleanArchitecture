using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Commands.PromotionCommands.Delete
{
    public class DeletePromotionRequest
    {
        public DeletePromotionRequest() { }
        public DeletePromotionRequest(string promotionId)
        {
            PromotionId = promotionId;
        }
        public string PromotionId { get; set; }
    }
}
