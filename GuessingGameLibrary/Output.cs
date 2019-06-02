using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameLibrary
{

    public delegate void ClientOutput(string message);

    public static class Output
    {
        public static void ClientPrintTabHead(List<Player> players, ClientOutput output)
        {
            string line = "|";
            foreach (Player player in players)
            {
                string strPlayerType = player.PlayerType;
                line += $" {strPlayerType.PadRight(15, ' ')}|";
            }
            output(line);
        }

        public static void ClientPrintTabLine(Dictionary<Player, int> dictMove, ClientOutput output)
        {
            string line = "|";
            foreach (KeyValuePair<Player, int> lineDict in dictMove)
            {
                string strPlayer = lineDict.Key.Name;
                string strValue = Convert.ToString(lineDict.Value);
                line += $" {strPlayer.PadRight(10, ' ')}|{strValue.PadLeft(4, ' ')}|";
            }
            output(line);
        }

        public static void ClientPrintLine(string message, ClientOutput output)
        {
            output(message);
        }
    }
}
