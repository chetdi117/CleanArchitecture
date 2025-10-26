using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Commands.UserCommands.Create
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public CreateUserCommand(CreateUserRequest request)
        {
            Payload = request;
        }

        public CreateUserRequest Payload { get; }
    }
}
