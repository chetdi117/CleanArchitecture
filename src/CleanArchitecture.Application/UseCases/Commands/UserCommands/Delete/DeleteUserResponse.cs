using CleanArchitecture.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Commands.UserCommands.Delete
{
    public class DeleteUserResponse : ErrorResponse
    {
        public static DeleteUserResponse Result() => new DeleteUserResponse { Success = true };

        public static DeleteUserResponse Fail(string message = "") => new DeleteUserResponse { Success = false, Message = message };
    }
}
