using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameLibrary
{
    public class Main
    {
        public List<Player> players = new List<Player>();
        Random random = new Random(new System.DateTime().Millisecond);
        public static Matrix matrix = new Matrix();

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
            //dict.Add(1, new GetPlayer(delegate { new Notepad(matrix); }));
            //dict.Add(2, new GetPlayer(delegate { new Regular(matrix); }));
            //dict.Add(3, new GetPlayer(delegate { new UberPlayer(matrix); }));
            //dict.Add(4, new GetPlayer(delegate { new Cheater(matrix); }));
            //dict.Add(5, new GetPlayer(delegate { new UberCheater(matrix); }));

            Player player = dict[1].Invoke( matrix, "Player1");

            //Create random qty players
            for (int i = 0; i < random.Next(2, 8); i++)
            {
                //players.Add(GetRandomPlayer());
                //players.Add(dict[1].Invoke());
            }
        }

        public Player GetRandomPlayer()
        {
            
            int rnd = random.Next(1, 5);
            //****
            //return new Notepad(matrix);
            return null;
        }

        public Player GetAlmostWinner()
        {
            return null;
        }


    }
}
