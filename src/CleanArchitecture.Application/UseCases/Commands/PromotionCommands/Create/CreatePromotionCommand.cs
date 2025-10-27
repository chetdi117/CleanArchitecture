using CleanArchitecture.Application.UseCases.Commands.UserCommands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Commands.PromotionCommands.Create
{
    // Renamed the class to avoid conflict with the existing definition
    public class CreatePromotionCommand : IRequest<CreatePromotionResponse>
    {
        public CreatePromotionRequest Payload { get; }

        public CreatePromotionCommand(CreatePromotionRequest payload)
        {
            Payload = payload;
        }
    }
}
