using MediatR;
using Microsoft.AspNetCore.Mvc;
using tictactoe.domain.Commands;
using tictactoe.domain.Queries;

namespace tictactoe.api.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createPlayer")]
        public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerRequest request)
        {
            var playerId = await _mediator.Send(new CreatePlayerCommand(request.Name));
            return CreatedAtAction(nameof(CreatePlayer), new { id = playerId }, playerId);
        }

        [HttpGet("getPlayers")]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _mediator.Send(new GetPlayersQuery());
            return Ok(players);
        }

    }

    public record CreatePlayerRequest(string Name);

}
