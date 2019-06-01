﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameLibrary
{
    public abstract class Player
    {
        public string Name { get; }
        public Matrix Matrix { get; private set; } = null;
        public abstract string PlayerType { get;}
        public abstract bool CheckMove(int move);
        public abstract int GetNewMove();

        public Player(Matrix matrix, string name)
        {
            Matrix = matrix;
            Name = name;
        }
    }
}
