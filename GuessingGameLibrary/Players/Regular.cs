using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameLibrary
{
    public class Regular : Player
    {
        public override string PlayerType => "Regular";

        public Regular(Matrix matrix, string name) : base(matrix, name) { }

        public override bool CheckMove(int move)
        {
            return true; //Not used
        }

        public override int GetNewMove()
        {
            return random.Next(40, 140);
        }
    }
}
