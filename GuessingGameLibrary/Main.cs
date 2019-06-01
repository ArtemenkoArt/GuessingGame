using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameLibrary
{
    public class Main
    {
        public int Finish { get; }
        public List<Player> players = new List<Player>();
        public Matrix Matrix { get; private set; }
        public Player Winner { get; private set; }

        public delegate Player GetPlayer(Matrix matrix, string name);
        private static Dictionary<int, GetPlayer> dict = new Dictionary<int, GetPlayer>
        {
            { 1, new GetPlayer(delegate (Matrix matrix, string name) { return new Notepad(matrix, name); }) },
            { 2, new GetPlayer(delegate (Matrix matrix, string name) { return new Regular(matrix, name); }) },
            { 3, new GetPlayer(delegate (Matrix matrix, string name) { return new UberPlayer(matrix, name); })},
            { 4, new GetPlayer(delegate (Matrix matrix, string name) { return new Cheater(matrix, name); })},
            { 5, new GetPlayer(delegate (Matrix matrix, string name) { return new UberCheater(matrix, name); })}
        };

        public Main()
        {
            Finish = rnd.GetRandom(40, 140);
            Matrix = new Matrix();
        }

        public Player GetRandomTypePlayer(string name)
        {
            return dict[rnd.GetRandom(1, 6)].Invoke(Matrix, name);
        }

        public void AddNewPlayer(string playerName)
        {
           players.Add(GetRandomTypePlayer(playerName));
        }

        public Player GetAlmostWinner()
        {
            var pp = Matrix.GetAlmostWinner(Finish);
            return null;
        }

        public int PlayerMove(Player player)
        {
            int move = player.GetNewMove();
            Matrix.PlayerMoove(player, move);

            if (move == Finish)
                Winner = player;

            return move;
        }

    }
}
