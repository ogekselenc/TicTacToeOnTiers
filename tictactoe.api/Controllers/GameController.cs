using MediatR;
using Microsoft.AspNetCore.Mvc;
using tictactoe.domain.Commands;

namespace tictactoe.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] CreateGameRequest request)
        {
            var gameId = await _mediator.Send(new CreateGameCommand(request.BoardSize, request.WinningLineLength));
            return CreatedAtAction(nameof(CreateGame), new { id = gameId }, gameId);
        }
        public record CreateGameRequest(int BoardSize, int WinningLineLength);


        [HttpPost("{gameId}/join")]
        public async Task<IActionResult> JoinGame(int gameId, [FromBody] JoinGameRequest request)
        {
            var success = await _mediator.Send(new JoinGameCommand(gameId, request.PlayerId));
            return success ? Ok("Player joined successfully!") : BadRequest("Game full or invalid request.");
        }
        public record JoinGameRequest(int PlayerId);

        [HttpPost("{gameId}/move")]
        public async Task<IActionResult> MakeMove(int gameId, [FromBody] MakeMoveRequest request)
        {
            var success = await _mediator.Send(new MakeMoveCommand(gameId, request.PlayerId, request.Row, request.Column));
            return success ? Ok("Move made successfully!") : BadRequest("Invalid move.");
        }

        public record MakeMoveRequest(int PlayerId, int Row, int Column);
    }
}
