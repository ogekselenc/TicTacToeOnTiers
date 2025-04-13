// GetPlayersQuery.cs
using MediatR;
using System.Collections.Generic;
using tictactoe.data.Repositories;
using tictactoe.domain.DTOs;


namespace tictactoe.domain.Queries
{
    public class GetPlayersHandler : IRequestHandler<GetPlayersQuery, List<PlayerDTO>>
    {
        private readonly IPlayerReadRepository _playerReadRepository;

        public GetPlayersHandler(IPlayerReadRepository playerReadRepository)
        {
            _playerReadRepository = playerReadRepository;
        }

        public async Task<List<PlayerDTO>> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
        {
            var players = await _playerReadRepository.GetAllPlayersAsync();

            return players.Select(p => new PlayerDTO
            {
                Id = p.Id,
                Name = p.Name,

            }).ToList();
        }
    }
}