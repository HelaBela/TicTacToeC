using System;
using System.Collections.Generic;
using System.Linq;


namespace TicTacToe
{
    public class Board
    {
        public List<string> GameBoard { get; private set; }

        private List<List<int>> _winningPositions = new List<List<int>>()
        {
            new List<int>() {0, 1, 2},
            new List<int>() {3, 4, 5},
            new List<int>() {6, 7, 8},
            new List<int>() {0, 3, 6},
            new List<int>() {1, 4, 7},
            new List<int>() {2, 5, 8},
            new List<int>() {0, 4, 8},
            new List<int>() {2, 4, 6}
        };

        private readonly IConsoleService _consoleService;


        public Board(IConsoleService consoleService)
        {
            _consoleService = consoleService;
            Reset();
        }

        public void Draw()
        {
            _consoleService.Write("   {0}  |  {1}  |  {2}   ", GameBoard[0], GameBoard[1], GameBoard[2]);
            _consoleService.Write("   {0}  |  {1}  |  {2}   ", GameBoard[3], GameBoard[4], GameBoard[5]);
            _consoleService.Write("   {0}  |  {1}  |  {2}   ", GameBoard[6], GameBoard[7], GameBoard[8]);
        }


        public void SetChoice(string player)
        {
            var choiceSuccessful = false;
            while (!choiceSuccessful)
            {
                var selection = GetPlayerSelection(player);
                if (GameBoard[selection] == ".")
                {
                    GameBoard[selection] = player;
                    choiceSuccessful = true;
                }
                else
                {
                    _consoleService.Write("this spot is taken. Choose something else");
                }
            }
        }

        public bool HasAWinner(List<string> board, string player)
        {
            foreach (var winningPosition in _winningPositions)
            {
                if (winningPosition.All(i => board[i] == player)) return true;
            }

            return false;
        }

        public bool IsATie(List<string> board, string player)
        {
            return board.All(s => s != ".") && !HasAWinner(board, player);
        }


        private int GetPlayerSelection(string player)
        {
            while (true)
            {
                _consoleService.Write(($"Player: {player}"));
                _consoleService.Write("Please enter your selection: numbers 0-8");

                if (int.TryParse(_consoleService.Read(), out int result) && result <= 8)
                {
                    return result;
                }

                _consoleService.Write("sorry, wrong choice. Try again.");
            }
        }

        public void Reset()
        {
            GameBoard = new List<string>() {".", ".", ".", ".", ".", ".", ".", ".", "."};
        }
    }
}