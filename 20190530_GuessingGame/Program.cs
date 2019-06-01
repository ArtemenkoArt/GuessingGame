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

        static public void PrintHead(List<Player> players)
        {
            string line = "|";
            foreach (Player player in players)
            {
                string strPlayerType = player.PlayerType;
                line += $" {strPlayerType.PadRight(15, ' ')}|";
            }
            Console.WriteLine(line);
        }

        static public void PrintLine(Dictionary<Player, int> dictMove)
        {
            string line = "|";
            foreach (KeyValuePair<Player, int> lineDict in dictMove)
            {
                string strPlayer = lineDict.Key.Name;
                string strValue = Convert.ToString(lineDict.Value);
                line += $" {strPlayer.PadRight(10,' ')}|{strValue.PadLeft(4, ' ')}|";
            }
            Console.WriteLine(line);
        }

        static void Main(string[] args)
        {
           
            Main main = new Main();

            int qtyPlayers = GetUserChoise("Enter the number of players (2 - 8 players): ");
            if (qtyPlayers < 2 || qtyPlayers > 8)
            {
                Console.WriteLine("The number of players must be 2 - 8...");
                Console.ReadKey();
                Environment.Exit(0);
            }

            for (int i = 1; i <= qtyPlayers; i++)
            {
                Console.Write($"Enter name Player{i}: ");
                string playerName = Console.ReadLine();
                main.AddNewPlayer(playerName);
            }

            Console.Clear();
            PrintHead(main.players);

            int totalMove = 100;
            while (totalMove > 0 && main.Winner == null)
            {
                Dictionary<Player, int> playersMove = new Dictionary<Player, int>();

                foreach (Player player in main.players)
                {
                    if (main.Winner != null || totalMove <= 0)
                    {
                        break;
                    }

                    totalMove--;
                    int move = main.PlayerMove(player);
                    playersMove.Add(player, move);
                }
                PrintLine(playersMove);
            }

            Console.WriteLine($"Finish value: {main.Finish}");
            var aw = main.GetAlmostWinner();

            if (main.Winner == null)
            {
                Console.WriteLine($"There is no winner. The closest of all was: {main.GetAlmostWinner()}");
            }
            else
            {
                Console.WriteLine($"WINNER - player: {main.Winner.Name} ({main.Winner.PlayerType})");
            }

            Console.ReadKey();
        }
    }
}
