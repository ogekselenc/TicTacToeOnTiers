using System;
using System.Collections.Generic;

namespace tictactoe.api.tictactoe.data.Models;

public partial class Player
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<Game> GamePlayerOs { get; set; } = new List<Game>();

    public virtual ICollection<Game> GamePlayerXes { get; set; } = new List<Game>();
}
