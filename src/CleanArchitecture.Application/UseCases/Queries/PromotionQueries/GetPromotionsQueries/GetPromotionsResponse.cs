using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.UseCases.Queries.UserQueries.GetUsersQueries;
using CleanArchitecture.Domain.DTO;
using CleanArchitecture.Domain.Entities.Promotion;


namespace CleanArchitecture.Application.UseCases.Queries.PromotionQueries.GetPromotionsQueries
{
    public class GetPromotionsResponse: ErrorResponse
    {
        public required IEnumerable<PromotionDTO> Promotions { get; set; }

        public static GetPromotionsResponse Result(IEnumerable<PromotionDTO> promotions)
        {
            return new GetPromotionsResponse
            {
                Success = true,
                Promotions = promotions
            };
        }

        public static GetPromotionsResponse NotFound()
        {
            return new GetPromotionsResponse
            {
                Success = true,
                Promotions = Enumerable.Empty<PromotionDTO>()
            };
        }

        public static GetPromotionsResponse Fail(string message)
        {
            return new GetPromotionsResponse
            {
                Promotions = Enumerable.Empty<PromotionDTO>(),
                Success = false,
                Message = message
            };
        }
    }
}
