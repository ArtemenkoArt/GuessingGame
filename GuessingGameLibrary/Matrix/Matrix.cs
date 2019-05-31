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
            else
            {
                if (playerMoves.Find((x) => (x.Move == value) && (x.Player == player)) == null)
                    return true;
            }
            return false;
        }

        //public int GetMaxPlayerMove(Player player, int startValue = 0)
        //{
        //    if (startValue == 0)
        //    {
        //        var move = playerMoves.FindAll((x) => x.Player == player).Max((x) => x.Move);
        //        return move;
        //    }
        //    else
        //    {
        //        var move = playerMoves.FindAll((x) => x.Player == player && x.Move >= startValue).Max((x) => x.Move);
        //        return move;
        //    }
        //}

        public void PlayerMoove(Player player, int move)
        {
            playerMoves.Add(new PlayerMove(player, move));
        }
    }
}
