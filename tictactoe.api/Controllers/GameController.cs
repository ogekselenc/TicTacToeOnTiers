using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using tictactoe.domain.Commands;
using tictactoe.domain.Queries;
using MediatR;
using tictactoe.data;
using System.Net;
using Microsoft.EntityFrameworkCore;
using tictactoe.data.Entities;

namespace tictactoe.api.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppDbContext Context { get; }

        

        public GameController(IMediator mediator, AppDbContext context)
        {
            _mediator = mediator;
            Context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateGame([FromBody] CreateGameCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("{gameId}/join")]
        public async Task<IActionResult> JoinGame(int gameId, [FromBody] JoinGameCommand command)
        {
            if (gameId != command.GameId) return BadRequest("Game ID mismatch.");
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{gameId}")]
        public async Task<IActionResult> GetGameById(int gameId)
        {
            var query = new GetGameQuery(gameId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("delete/{gameId}")]
        public async Task<bool> SoftDeleteGameCommand(int gameId)
        {
            return await _mediator.Send(new SoftDeleteGameCommand(gameId));
        }
    }
}
