

using CleanArchitecture.Application.Models;

namespace CleanArchitecture.Application.UseCases.Queries.UserQueries.GetUsersQueries
{
    public class GetUsersResponse : ErrorResponse
    {
        public required IEnumerable<UserDTO> Users { get; set; }

        public static GetUsersResponse Result(IEnumerable<UserDTO> users)
        {
            return new GetUsersResponse
            {
                Success = true,
                Users = users
            };
        }

        public static GetUsersResponse NotFound()
        {
            return new GetUsersResponse
            {
                Success = true,
                Users = Enumerable.Empty<UserDTO>()
            };
        }

        public static GetUsersResponse Fail(string message)
        {
            return new GetUsersResponse
            {
                Users = Enumerable.Empty<UserDTO>(),
                Success = false,
                Message = message
            };
        }
    }
}
