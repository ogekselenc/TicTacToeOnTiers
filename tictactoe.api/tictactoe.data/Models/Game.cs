using System;
using System.Collections.Generic;

namespace tictactoe.api.tictactoe.data.Models;

public partial class Game
{
    public int Id { get; set; }

    public int BoardSize { get; set; }

    public int? PlayerXid { get; set; }

    public int? PlayerOid { get; set; }

    public int Status { get; set; }

    public bool IsDeleted { get; set; }

    public string? OutcomeReason { get; set; }

    public int OutcomeStatus { get; set; }

    public int WinningLineLength { get; set; }

    public virtual ICollection<Move> Moves { get; set; } = new List<Move>();

    public virtual Player? PlayerO { get; set; }

    public virtual Player? PlayerX { get; set; }
}
