using System;
using System.Collections.Generic;

namespace tictactoe.api.tictactoe.data.Models;

public partial class Move
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public int PlayerId { get; set; }

    public int Row { get; set; }

    public int Column { get; set; }

    public virtual Game Game { get; set; } = null!;
}
