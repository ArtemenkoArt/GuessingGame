using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameLibrary
{
    public class UberCheater : Player
    {
        public override string PlayerType => "UberCheater";

        public UberCheater(GameMove matrix, string name) : base(matrix, name) { }

        public override bool CheckMove(int move)
        {
            return Matrix.CheckValue(move);
        }

        public override int GetNewMove()
        {
            int currentMove = 0;
            for (int i = 40; i <= 100; i++)
            {
                if (CheckMove(i))
                {
                    currentMove = i;
                    break;
                }
            }
            return currentMove;
        }
    }
}
