using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameLibrary
{
    public class Matrix
    {
        List<PlayerMove> playerMoves = new List<PlayerMove>();

        public Matrix()
        {
            //
        }

        public bool CheckValue(int value, Player player = null)
        {
            if (player == null)
            {
                if (playerMoves.Find((x) => x.Move == value) == null)
                    return true;
            }
            if (playerMoves.Find((x) => (x.Move == value) && (x.Player == player)) == null)
                return true;
            return false;
        }

        public void PlayerMoove(Player player, int move)
        {
            playerMoves.Add(new PlayerMove(player, move));
        }
    }
}
