using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using tictactoe.domain.Commands;
using tictactoe.domain.Queries;
using MediatR;

namespace tictactoe.api.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create a new game. The first player is assigned, but the game waits for the second player.
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> CreateGame([FromBody] CreateGameCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Join an existing game as the second player.
        /// </summary>
        [HttpPost("{gameId}/join")]
        public async Task<IActionResult> JoinGame(int gameId, [FromBody] JoinGameCommand command)
        {
            if (gameId != command.GameId) return BadRequest("Game ID mismatch.");
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    

        /// <summary>
        /// Get the current game state.
        /// </summary>
        [HttpGet("{gameId}/state")]
        public async Task<IActionResult> GetGame(int gameId)
        {
            var query = new GetGameStateQuery { GameId = gameId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
