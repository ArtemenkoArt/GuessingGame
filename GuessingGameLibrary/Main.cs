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

        private Dictionary<int, Delegate> dict = new Dictionary<int, Delegate>();
        public delegate void Delegate(Matrix matrix);

        public Main()
        {
            //Create random qty players
            for (int i = 0; i < random.Next(2, 8); i++)
            {
                players.Add(GetRandomPlayer());
            }
        }

        public Player GetRandomPlayer()
        {
            
            //dict.Add(1, new Delegate(new Notepad(matrix)));
            //dict.Add(2, new Delegate(Func2));
            //dict.Add(3, new Delegate(Func3));

            Random random = new Random(new System.DateTime().Millisecond);
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
