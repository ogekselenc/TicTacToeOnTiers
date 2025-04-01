using MediatR;
using System;
using tictactoe.domain.Models;

namespace tictactoe.domain.Queries
{
    public class GetGameStateQuery : IRequest<GameStateDto>
    {
        public Guid GameId { get; set; }
    }
}
