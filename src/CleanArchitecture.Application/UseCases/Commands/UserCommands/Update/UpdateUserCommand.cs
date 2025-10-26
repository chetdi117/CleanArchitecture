using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Commands.UserCommands.Update
{
    public class UpdateUserCommand: IRequest<UpdateUserResponse>
    {
        public UpdateUserCommand(string UserId, UpdateUserRequest request)
        {
            Payload = request;
            UserId = UserId;
        }
        public string UserId { get; set; }
        public UpdateUserRequest Payload { get; }
    }
}
