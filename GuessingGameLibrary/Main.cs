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

        public delegate Player GetPlayer(Matrix matrix);

        private static Dictionary<int, GetPlayer> dict = new Dictionary<int, GetPlayer>
        {
            { 1, new GetPlayer(delegate (Matrix matrix) { return new Notepad(matrix); }) },
            { 2, new GetPlayer(delegate (Matrix matrix) { return new Regular(matrix); }) },
            { 3, new GetPlayer(delegate (Matrix matrix) { return new UberPlayer(matrix); })},
            { 4, new GetPlayer(delegate (Matrix matrix) { return new Cheater(matrix); })},
            { 5, new GetPlayer(delegate (Matrix matrix) { return new UberCheater(matrix); })}
        };


        public Main()
        {
            //dict.Add(1, new GetPlayer(delegate { new Notepad(matrix); }));
            //dict.Add(2, new GetPlayer(delegate { new Regular(matrix); }));
            //dict.Add(3, new GetPlayer(delegate { new UberPlayer(matrix); }));
            //dict.Add(4, new GetPlayer(delegate { new Cheater(matrix); }));
            //dict.Add(5, new GetPlayer(delegate { new UberCheater(matrix); }));

            Player player = dict[1].Invoke( matrix );

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
            return new Notepad(matrix);
        }

        public Player GetAlmostWinner()
        {
            return null;
        }


    }
}
