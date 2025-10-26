using CleanArchitecture.Application.UseCases.Queries.UserQueries;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Queries.UserQueries.GetUsersQueries
{
    public class GetUsersQuery : IRequest<GetUsersResponse>
    {
        public GetUsersQuery(GetUsersRequest request)
        {
            Payload = request;
        }

        public GetUsersRequest Payload { get; set; }
    }
}
