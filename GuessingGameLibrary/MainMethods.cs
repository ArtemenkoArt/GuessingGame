using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameLibrary
{
    public class MainMethods
    {
        public List<Player> players = new List<Player>();
        Random random = new Random(new System.DateTime().Millisecond);
        public static Matrix matrix = new Matrix();
        //public Matrix matrix = new Matrix();

        public MainMethods()
        {
            //Create random qty players
            for (int i = 0; i < random.Next(2, 8); i++)
            {
                players.Add(GetRandomPlayer());
            }
        }

        public Player GetRandomPlayer()
        {
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
