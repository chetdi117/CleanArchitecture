using CleanArchitecture.API.Extensions;
using CleanArchitecture.Application.Factory;
using CleanArchitecture.Application.UseCases.Commands.PromotionCommands.Create;
using CleanArchitecture.Application.UseCases.Commands.PromotionCommands.Delete;
using CleanArchitecture.Application.UseCases.Commands.PromotionCommands.Update;
using CleanArchitecture.Application.UseCases.Commands.UserCommands.Delete;
using CleanArchitecture.Application.UseCases.Queries.PromotionQueries.GetPromotionsQueries;
using CleanArchitecture.Application.UseCases.Queries.UserQueries.GetUsersQueries;
using CleanArchitecture.Domain.DTO;
using CleanArchitecture.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Optional;

namespace CleanArchitecture.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PromotionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("promotions")]
        [ProducesResponseType(typeof(BaseApiResponse<List<UserDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _mediator.Send(new GetPromotionsQuery(new GetPromotionsRequest()));
            return response.Some().ToActionResult(response.Success, response.ErrorCode, response.Message);
        }

        [HttpPost("promotion")]
        [ProducesResponseType(typeof(BaseApiResponse<PromotionDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatePromotion([FromBody] PromotionFormDTO form)
        {
            if (form == null)
            {
                return BadRequest("Promotion form data is required.");
            }

            var response = await _mediator.Send(new CreatePromotionCommand(new CreatePromotionRequest()
            {
                Title = form.Title,
                StartDate = form.StartDate,
                EndDate = form.EndDate,
                DiscountPercentage = form.DiscountPercentage
            }));

            return Ok(ApplicationFactory.CreateSuccessResponse<string>(response.PromotioId));
        }

        [HttpPut("promotion/{id}")]
        [ProducesResponseType(typeof(BaseApiResponse<PromotionDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatePromotion(string id, [FromBody] PromotionFormDTO form)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Promotion ID cannot be null or empty.");
            }
            if (form == null)
            {
                return BadRequest("Promotion form data is required.");
            }

            var response = await _mediator.Send(new UpdatePromotionCommand(id,new UpdatePromotionRequest()
            {
                Title = form.Title,
                StartDate = form.StartDate,
                EndDate = form.EndDate,
                DiscountPercentage = form.DiscountPercentage
            }));

            return Ok(ApplicationFactory.CreateSuccessResponse<bool>(response.Data));
        }

        [HttpDelete("promotion/{id}")]
        [ProducesResponseType(typeof(BaseApiResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Promotion ID cannot be null or empty.");
            }
            var response = await _mediator.Send(new DeletePromotionCommand(new DeletePromotionRequest(id)));
            return response.Some().ToActionResult(response.Success, response.ErrorCode, response.Message);
        }
    }
}
