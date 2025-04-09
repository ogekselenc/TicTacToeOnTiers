using MediatR;
using Microsoft.AspNetCore.Mvc;
using tictactoe.data;
using tictactoe.data.Entities;
using tictactoe.domain.Commands;
using tictactoe.domain.Queries;

namespace tictactoe.api.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppDbContext Context { get; }

        public PlayerController(IMediator mediator, AppDbContext context)
        {
            Context = context;
            _mediator = mediator;

        }

        [HttpPost("createPlayer")]
        public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerRequest request)
        {
            var playerXId = await _mediator.Send(new CreatePlayerCommand(request.Name));
            return CreatedAtAction(nameof(CreatePlayer), new { id = playerXId }, playerXId);
        }

        [HttpGet("getPlayers")]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _mediator.Send(new GetPlayersQuery());
            return Ok(players);
        }

        [HttpPost("add")]
        public async Task<IActionResult> GetPlayers(Player player)
        {
            await Context.Players.AddAsync(player);
            await Context.SaveChangesAsync();
            return Ok();
        }


    }

    public record CreatePlayerRequest(string Name);

}
