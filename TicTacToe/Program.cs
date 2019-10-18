using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleService = new ConsoleOperations();
            var board = new Board(consoleService);
            var game = new Game(board, consoleService);

            var keepPlaying = true;
            while (keepPlaying)
            {
                game.Reset();
                game.Play();

                consoleService.Write("if you want to keep playing press 'a'");
                keepPlaying = consoleService.Read() == "a";
            }
        }
    }
}