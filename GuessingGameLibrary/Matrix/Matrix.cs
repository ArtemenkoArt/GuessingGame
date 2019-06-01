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

        public Player GetAlmostWinner(int finish)
        {
            var result =
                        (from diffVal in
                        (
                            from maxWin in playerMoves
                            orderby maxWin.Move
                            select new
                            {
                                Player = maxWin.Player,
                                Move = maxWin.Move,
                                diff = (maxWin.Move - finish) * 1
                            }
                         )
                         orderby diffVal.diff
                         select diffVal.Player).Take(1);

            //return (Player)result;
            return null;
        }

        public void PlayerMoove(Player player, int move)
        {
            playerMoves.Add(new PlayerMove(player, move));
        }
    }
}
