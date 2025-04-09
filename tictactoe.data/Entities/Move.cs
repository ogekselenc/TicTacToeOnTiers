using System;
using System.Collections.Generic;

namespace tictactoe.data.Entities
{
    public partial class Move
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public int PlayerId { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}