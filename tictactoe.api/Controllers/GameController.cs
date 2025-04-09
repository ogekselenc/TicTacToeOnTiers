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

        public GameService GameService { get; }

        public GameController(IMediator mediator, AppDbContext context, GameService gameService)
        {
            _mediator = mediator;
            Context = context;
            GameService = gameService;
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

        [HttpGet("{gameId}")]
        public async Task<IActionResult> GetGameById(int gameId)
        {
            var query = new GetGameQuery(gameId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("get/{gameId}")]
        public async Task<Game> GetById(int gameId)
        {
            return await GameService.GetGameById(gameId);
        }

        [HttpPost("delete/{gameId}")]
        public async Task<bool> Delete(int gameId)
        {
            return await GameService.Delete(gameId);
        }

        [HttpPost("add")]
        public async Task<bool> Add(Game game)
        {
            return await GameService.Add(game);
        }
    }
}
