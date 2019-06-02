using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameLibrary
{
    public class Game
    {
        
        public int Finish { get; }
        public List<Player> players = new List<Player>();
        public Matrix Matrix { get; private set; }
        public Player Winner { get; private set; }

        public delegate Player GetPlayer(Matrix matrix, string name);
        private static Dictionary<int, GetPlayer> dict = new Dictionary<int, GetPlayer>
        {
            { 1, new GetPlayer(delegate (Matrix matrix, string name) { return new Notepad(matrix, name); }) },
            { 2, new GetPlayer(delegate (Matrix matrix, string name) { return new Regular(matrix, name); }) },
            { 3, new GetPlayer(delegate (Matrix matrix, string name) { return new UberPlayer(matrix, name); })},
            { 4, new GetPlayer(delegate (Matrix matrix, string name) { return new Cheater(matrix, name); })},
            { 5, new GetPlayer(delegate (Matrix matrix, string name) { return new UberCheater(matrix, name); })}
        };

        public Game()
        {
            Finish = rnd.GetRandom(40, 240);
            Matrix = new Matrix();
        }

        public Player GetRandomTypePlayer(string name)
        {
            return dict[rnd.GetRandom(1, 6)].Invoke(Matrix, name);
        }

        public void AddPlayers(string[] names)
        {
            foreach (var name in names)
            {
                players.Add(GetRandomTypePlayer(name));
            }
        }

        public Player GetAlmostWinner()
        {
            //***var pp = Matrix.GetAlmostWinner(Finish);
            return null;
        }

        public int PlayerMove(Player player)
        {
            int move = player.GetNewMove();
            Matrix.PlayerMoove(player, move);

            if (move == Finish)
                Winner = player;

            return move;
        }

        public void StartGame(ClientOutput output)
        {
            Output.ClientPrintLine($"Finish value: {Finish}", output);
            Output.ClientPrintTabHead(players, output);

            int totalMove = 100;
            while (totalMove > 0 && Winner == null)
            {
                Dictionary<Player, int> playersMove = new Dictionary<Player, int>();

                foreach (Player player in players)
                {
                    if (Winner != null || totalMove <= 0)
                    {
                        break;
                    }

                    totalMove--;
                    int move = PlayerMove(player);
                    playersMove.Add(player, move);
                }
                Output.ClientPrintTabLine(playersMove, output);
            }

            if (Winner == null)
            {
                Output.ClientPrintLine($"There is no winner. The almost winner was: {GetAlmostWinner()}", output);
            }
            else
            {
                Output.ClientPrintLine($"WINNER - player: {Winner.Name} ({Winner.PlayerType})", output);
            }
        }
    }
}
