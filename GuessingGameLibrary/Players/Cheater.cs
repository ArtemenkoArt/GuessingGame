﻿using System;
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
            throw new NotImplementedException();
        }

        public override int GetNewMove()
        {
            throw new NotImplementedException();
        }
    }
}