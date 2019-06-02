using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessingGameLibrary;

namespace GuessingGame
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
                if (inputValue == "x" || inputValue == "X")
                    Environment.Exit(0);

                if (int.TryParse(inputValue, out flagExit))
                    if (flagExit == 0)
                        Console.WriteLine($"{Environment.NewLine}Value can not be zero, try again (enter X to exit):");
                    else
                        break;
                else
                    Console.WriteLine($"{Environment.NewLine}Input value not recognized, try again (enter X to exit):");
            }
            return flagExit;
        }

        static public string[] GetPlayersName()
        {
            int qtyPlayers = GetUserChoise("Enter the number of players (2 - 8 players): ");
            if (qtyPlayers < 2 || qtyPlayers > 8)
            {
                Console.WriteLine("The number of players must be 2 - 8...");
                Console.ReadKey();
                Environment.Exit(0);
            }

            string[] names = new string[qtyPlayers];
            for (int i = 0; i < qtyPlayers; i++)
            {
                Console.Write($"Enter name Player{i + 1}: ");
                string name = Console.ReadLine();
                names[i] = name.Length > 8 ? name.Substring(0,8) : name;
            }

            Console.Clear();
            return names;
        }

        static public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            GuessingGameLibrary.ClientOutput output = PrintMessage;
            Game game = new Game();

            game.AddPlayers(GetPlayersName());
            game.StartGame(output);

            Console.ReadKey();
        }
    }
}
