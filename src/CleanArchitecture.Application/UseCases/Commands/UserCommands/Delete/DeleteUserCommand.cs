using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Commands.UserCommands.Delete
{
    public class DeleteUserCommand: IRequest<DeleteUserResponse>
    {
        public DeleteUserCommand(DeleteUserRequest request)
        {
            Payload = request;
        }

        public DeleteUserRequest Payload { get; }
    }
}
