

using CleanArchitecture.Application.Models;
using CleanArchitecture.Infrastructure.Data;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CleanArchitecture.Application.UseCases.Queries.UserQueries.GetUsersQueries
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, GetUsersResponse>
    {
        private readonly MongoDbContext _dbContext;
        private readonly ILogger<GetUsersHandler> _logger;

        public GetUsersHandler(ILogger<GetUsersHandler> logger, MongoDbContext mongoDbContext)
        {
            _logger = logger;
            _dbContext = mongoDbContext;
        }

        public async Task<GetUsersResponse> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var prefixLog = $"{nameof(GetUsersHandler)}";
            //_logger.LogInformation($"{prefixLog} - request");
            try
            {
                //var payload = request.Payload;
                var userQuery = await MongoDB.Driver.Linq.MongoQueryable.ToListAsync(_dbContext.Users.AsQueryable(), cancellationToken);
                List<UserDTO> users = userQuery.ConvertAll(user => new UserDTO
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    Phone = user.Phone,
                });

                return GetUsersResponse.Result(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{prefixLog} - Error message: {ex.Message}");
                return GetUsersResponse.Fail(ex.Message);
            }
        }
    }
}
