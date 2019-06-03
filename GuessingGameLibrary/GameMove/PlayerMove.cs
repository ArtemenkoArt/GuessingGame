using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameLibrary
{
    public class PlayerMove
    {
        public int Move { get; private set; }
        public Player Player { get; private set; }

        public PlayerMove(Player player, int move)
        {
            Player = player;
            Move = move;
        }
    }
}
