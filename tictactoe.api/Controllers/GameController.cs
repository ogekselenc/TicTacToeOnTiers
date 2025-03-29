using MediatR;
using Microsoft.AspNetCore.Mvc;
using tictactoe.data.Repositories;


[ApiController]
[Route("api/games")]
public class GameController : ControllerBase
{
    private readonly IMediator _mediator;

    public GameController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGame([FromBody] CreateGameCommand command)
    {
        var gameId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetGame), new { id = gameId }, gameId);
    }

    [HttpPost("{id}/moves")]
    public async Task<IActionResult> MakeMove([FromRoute] int id, [FromBody] MakeMoveCommand command)
    {
        command.GameId = id;
        var result = await _mediator.Send(command);
        return result ? Ok() : BadRequest("Invalid move");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGame(int id)
    {
        var game = await _mediator.Send(new GetGameQuery { GameId = id });
        return game != null ? Ok(game) : NotFound();
    }
}
