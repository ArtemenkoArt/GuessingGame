using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameLibrary
{
    public abstract class Player
    {
        public Random random = new Random(new System.DateTime().Millisecond);
        public Matrix Matrix { get; private set; } = null;
        public abstract bool CheckMove(int move);
        public abstract int GetNewMove();

        public Player(Matrix matrix)
        {
            Matrix = matrix;
        }
    }
}
