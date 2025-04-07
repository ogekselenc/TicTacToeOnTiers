using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using tictactoe.domain.Commands;
using tictactoe.domain.Queries;
using MediatR;

namespace tictactoe.api.Controllers
{

    [ApiController]
    [Route("api")]
    public class MoveController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoveController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Make a move in an active game (only when both players have joined).
        /// </summary>
        [HttpPost("{gameId}/move")]
        public async Task<IActionResult> MakeMove(int gameId, [FromBody] MakeMoveRequest request)
        {
            if (gameId != request.GameId) return BadRequest("Game ID mismatch.");
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}