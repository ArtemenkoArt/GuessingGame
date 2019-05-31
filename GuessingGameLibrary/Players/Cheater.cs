using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameLibrary
{
    public class Cheater : Player
    {
        public Cheater(Matrix matrix, string name) : base(matrix, name) { }

        public override bool CheckMove(int move)
        {
            return Matrix.CheckValue(move);
        }

        public override int GetNewMove()
        {
            bool GetNewMove = false;
            int currentMove = 0;
            //Do not exit the loop until we get the value without repeating
            while (!GetNewMove)
            {
                currentMove = random.Next(40, 140);
                if (CheckMove(currentMove))
                {
                    GetNewMove = true;
                }
            }
            return currentMove;
        }
    }
}
