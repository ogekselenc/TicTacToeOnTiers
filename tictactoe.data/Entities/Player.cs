using System;
using System.Collections.Generic;

namespace tictactoe.data.Entities
{
    public partial class Player
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}