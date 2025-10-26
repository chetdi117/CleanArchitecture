using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.UseCases.Commands.UserCommands.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Commands.UserCommands.Create
{
    public class CreateUserResponse : ErrorResponse
    {
        public string UserId { get; set; }
        public static CreateUserResponse Result(string userId)
            => new CreateUserResponse
            {
                UserId = userId
            };
        public static CreateUserResponse Fail(string message = "") => new CreateUserResponse { Success = false, Message = message };

    }
}
