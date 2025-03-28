using MediatR;

namespace tictactoe.domain.Commands
{
    public class CreatePlayerCommand : IRequest<int>
    {
        public string Name { get; set; }

        public CreatePlayerCommand(string name)
        {
            Name = name;
        }
    }
}
