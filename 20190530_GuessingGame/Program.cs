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

        static public int GetUserChoise(string msg)
        {
            int flagExit = 0;
            while (flagExit == 0)
            {
                Console.Write($"{msg}");
                string inputValue = Console.ReadLine();

                if (int.TryParse(inputValue, out flagExit))
                    if (flagExit == 0)
                        Console.WriteLine($"{Environment.NewLine}Value can not be zero, try again:");
                    else
                        break;
                else
                    Console.WriteLine($"{Environment.NewLine}Input value not recognized, try again:");
            }
            return flagExit;
        }

        static void Main(string[] args)
        {
           
            Main main = new Main();

            int qtyPlayers = GetUserChoise("Enter the number of players (2 - 8 players): ");
            for (int i = 1; i < qtyPlayers; i++)
            {
                Console.Write($"Enter name Player{i}:");
                string playerName = Console.ReadLine();
                main.players.Add(main.GetRandomTypePlayer(playerName));
            }

            //UI - 10%
            //Arhitect - 20%
            //OOP - 40
            //Logic - 30%

            int totalMove = 100;
            while (totalMove > 0 || main.winner == null)
            {
                for (int i = 0; i < main.players.Count || main.winner != null || totalMove > 0; i++)
                {
                    totalMove++;
                    Player currentPlayer = main.players[i];
                    int currentMove = main.PlayerMove(currentPlayer);

                    if (i == 0)
                    {
                        Console.WriteLine($"Player #{i-1} : {currentPlayer}, Move: {currentMove}");
                    }
                    else
                    {
                        Console.Write($"Player #{i-1} : {currentPlayer}, Move: {currentMove}");
                    }
                }
            }

            if (main.winner == null)
            {
                Console.WriteLine($"There is no winner. The closest of all was: {main.GetAlmostWinner()}");
            }

            Console.ReadKey();
        }
    }
}
