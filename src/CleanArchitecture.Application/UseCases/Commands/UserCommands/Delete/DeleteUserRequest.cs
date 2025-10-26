using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Commands.UserCommands.Delete
{
    public class DeleteUserRequest
    {
        public DeleteUserRequest() { }
        public DeleteUserRequest(string userId) {
            UserId = userId;
        }
        public string UserId { get; set; }
    }
}
