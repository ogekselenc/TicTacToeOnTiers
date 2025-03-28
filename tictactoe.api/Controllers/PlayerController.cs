using MediatR;
using Microsoft.AspNetCore.Mvc;
using tictactoe.domain.Commands;

namespace tictactoe.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerRequest request)
        {
            var playerId = await _mediator.Send(new CreatePlayerCommand(request.Name));
            return CreatedAtAction(nameof(CreatePlayer), new { id = playerId }, playerId);
        }
    }

    public record CreatePlayerRequest(string Name);
}
