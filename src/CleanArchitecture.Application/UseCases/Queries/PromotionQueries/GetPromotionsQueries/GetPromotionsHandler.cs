using CleanArchitecture.Domain.DTO;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Queries.PromotionQueries.GetPromotionsQueries
{
    public class GetPromotionsHandler : IRequestHandler<GetPromotionsQuery, GetPromotionsResponse>
    {
        private readonly MongoDbContext _dbContext;
        private readonly ILogger<GetPromotionsHandler> _logger;

        public GetPromotionsHandler(ILogger<GetPromotionsHandler> logger, MongoDbContext mongoDbContext)
        {
            _logger = logger;
            _dbContext = mongoDbContext;
        }

        public async Task<GetPromotionsResponse> Handle(GetPromotionsQuery request, CancellationToken cancellationToken)
        {
            var prefixLog = $"{nameof(GetPromotionsHandler)}";
            //_logger.LogInformation($"{prefixLog} - request");
            try
            {
                // Correct the issue by using ToListAsync() to execute the query and retrieve the data
                var promotionQuery = await _dbContext.Promotions.AsQueryable().ToListAsync(cancellationToken);

                // Map the retrieved promotions to the desired DTO
                List<PromotionDTO> promotions = promotionQuery.ConvertAll(p => new PromotionDTO
                {
                    Id = p.Id,
                    Title = p.Title,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    DiscountPercentage = p.DiscountPercentage
                });

                return GetPromotionsResponse.Result(promotions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{prefixLog} - Error message: {ex.Message}");
                return GetPromotionsResponse.Fail(ex.Message);
            }
        }
    }
}
