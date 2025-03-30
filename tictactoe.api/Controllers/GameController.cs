using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using tictactoe.domain.Commands;
using tictactoe.domain.Queries;
using tictactoe.domain.Services;
using MediatR;

namespace tictactoe.api.Controllers
{
    [Route("api/[controller]")]
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
            if (command.BoardSize < 3 || command.WinLength < 3 || command.WinLength > command.BoardSize)
            {
                return BadRequest("Invalid board size or winning length.");
            }

            var result = await _mediator.Send(command);
            if (result == 0) return BadRequest("Game could not be created.");

            return CreatedAtAction(nameof(GetGame), new { gameId = result }, result);
        }

        [HttpGet("{gameId}")]
        public async Task<IActionResult> GetGame(int gameId)
        {
            var query = new GetGameQuery(gameId);
            var result = await _mediator.Send(query);
            if (result == null) return NotFound($"Game with ID {gameId} not found.");

            return Ok(result);
        }

        [HttpPost("move")]
        public async Task<IActionResult> MakeMove([FromBody] MakeMoveCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result) return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{gameId}")]
        public async Task<IActionResult> SoftDeleteGame(int gameId)
        {
            var command = new SoftDeleteGameCommand(gameId);
            var result = await _mediator.Send(command);
            if (!result) return NotFound($"Game with ID {gameId} not found or already deleted.");

            return Ok($"Game with ID {gameId} has been deleted.");
        }
    }
}
