using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessingGameLibrary;

namespace _20190530_GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Random random = new Random(new System.DateTime().Millisecond);
            int BasketWeight = random.Next(40, 140);
            Main main = new Main();


            Player winner = null;

            //intrface - qty player
            //intrface - name & type in keyvord
            //create player with Library<var, delegate>

            //UI - 10%
            //Arhitect - 20%
            //OOP - 40
            //Logic - 30%

            for (int i = 1; i < 100; i++)
            {
                foreach (Player currentPlayer in main.players)
                {
                    //
                    int currentMove = currentPlayer.GetNewMove();
                    if (currentMove == BasketWeight)
                    {
                        //WINNER!!!!
                    }
                }
            }

            if (winner == null)
            {
                winner = main.GetAlmostWinner();
            }
        }
    }
}
