using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using tictactoe.domain.Commands;
using tictactoe.domain.Queries;
using MediatR;

namespace tictactoe.api.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateGame([FromBody] CreateGameCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new { gameId = result });
        }

        [HttpPost("{gameId}/join")]
        public async Task<IActionResult> JoinGame(int gameId, [FromBody] JoinGameCommand command)
        {
            if (gameId != command.GameId) return BadRequest("Game ID mismatch.");
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("{gameId}/move")]
        public async Task<IActionResult> MakeMove(int gameId, [FromBody] MakeMoveCommand command)
        {
            if (gameId != command.GameId) return BadRequest("Game ID mismatch.");
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
