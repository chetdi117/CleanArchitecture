

using CleanArchitecture.Application.Models;

namespace CleanArchitecture.Application.UseCases.Commands.UserCommands.Update
{
    public class UpdateUserResponse: ErrorResponse
    {
        public bool Data { get; set; }
        public static UpdateUserResponse Result(bool data)
            => new UpdateUserResponse
            {
                Data = data
            };
        public static UpdateUserResponse Fail(string message = "") => new UpdateUserResponse { Success = false, Message = message };
    }
}
