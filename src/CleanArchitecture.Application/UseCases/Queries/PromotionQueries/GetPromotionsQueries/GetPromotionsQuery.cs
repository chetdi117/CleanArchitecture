using CleanArchitecture.Application.UseCases.Queries.UserQueries.GetUsersQueries;

namespace CleanArchitecture.Application.UseCases.Queries.PromotionQueries.GetPromotionsQueries
{
    public class GetPromotionsQuery: IRequest<GetPromotionsResponse>
    {
        public GetPromotionsQuery(GetPromotionsRequest request)
        {
            Payload = request;
        }

        public GetPromotionsRequest Payload { get; set; }
    }
}
