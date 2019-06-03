﻿using System;
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
        public GameMove Moves { get; private set; }
        public Player Winner { get; private set; }

        public delegate Player GetPlayer(GameMove matrix, string name);
        private static readonly Dictionary<int, GetPlayer> playerTemplate = new Dictionary<int, GetPlayer>
        {
            { 1, new GetPlayer(delegate (GameMove matrix, string name) { return new Notepad(matrix, name); }) },
            { 2, new GetPlayer(delegate (GameMove matrix, string name) { return new Regular(matrix, name); }) },
            { 3, new GetPlayer(delegate (GameMove matrix, string name) { return new UberPlayer(matrix, name); })},
            { 4, new GetPlayer(delegate (GameMove matrix, string name) { return new Cheater(matrix, name); })},
            { 5, new GetPlayer(delegate (GameMove matrix, string name) { return new UberCheater(matrix, name); })}
        };

        public Game()
        {
            Finish = rnd.GetRandom(40, 240);
            Moves = new GameMove();
        }

        public Player GetRandomTypePlayer(string name)
        {
            return playerTemplate[rnd.GetRandom(1, 6)].Invoke(Moves, name);
        }

        public void AddPlayers(string[] names)
        {
            foreach (var name in names)
            {
                players.Add(GetRandomTypePlayer(name));
            }
        }

        public int PlayerMove(Player player)
        {
            int move = player.GetNewMove();
            Moves.PlayerMoove(player, move);

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
                Output.ClientPrintLine($"There is no winner. The almost winner was: {Moves.GetAlmostWinner(Finish)}", output);
            }
            else
            {
                Output.ClientPrintLine($"WINNER - player: {Winner.Name} ({Winner.PlayerType})", output);
            }
        }
    }
}
