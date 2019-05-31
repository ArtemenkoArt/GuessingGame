using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameLibrary
{
    public class Main
    {
        Random random = new Random(new System.DateTime().Millisecond);
        public int Finish { get; }
        public List<Player> players = new List<Player>();
        public Matrix matrix = new Matrix();
        public Player winner { get; private set; } = null;

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
            int Finish = random.Next(40, 140);
        }

        public Player GetRandomTypePlayer(string name)
        {
            return dict[random.Next(1, 5)].Invoke(matrix, name);
        }

        public Player GetAlmostWinner()
        {
            return null;
        }

        public int PlayerMove(Player player)
        {
            int move = player.GetNewMove();
            matrix.PlayerMoove(player, move);
            return move;
        }

    }
}
