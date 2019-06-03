using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameLibrary
{
    public class GameMove
    {
        List<PlayerMove> playerMoves = new List<PlayerMove>();

        //Checking the value in the list
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

        public string GetAlmostWinner(int finish)
        {
            SortedList<int, Player> playerPosition = new SortedList<int, Player>();
            foreach (PlayerMove move in playerMoves)
            {
                playerPosition[Math.Abs(move.Move - finish)] = move.Player;
            }
            return playerPosition.Values.ElementAt(0).Name;
        }

        public void PlayerMoove(Player player, int move)
        {
            playerMoves.Add(new PlayerMove(player, move));
        }
    }
}
