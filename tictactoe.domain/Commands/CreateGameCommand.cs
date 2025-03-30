using MediatR;

public class CreateGameCommand : IRequest<int>
{
    public int BoardSize { get; set; }  // ✅ Dodato
    public int WinLength { get; set; }  // ✅ Dodato
    public int? PlayerXId { get; set; }
    public int? PlayerOId { get; set; }
}
