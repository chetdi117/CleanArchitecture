using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Commands.PromotionCommands.Delete
{
    public class DeletePromotionCommand : IRequest<DeletePromotionResponse>
    {
        public DeletePromotionCommand(DeletePromotionRequest request)
        {
            Payload = request;
        }

        public DeletePromotionRequest Payload { get; }
    }
}
