namespace TicTacToe
{
    public class Game
    {
        private readonly Board _board;
        private readonly IConsoleService _consoleService;
        public string Player { get; private set; }


        public Game(Board board, IConsoleService consoleService)
        {
            _board = board;
            _consoleService = consoleService;
        }

        public void Play()
        {
            var tie = false;
            var winner = false;
            while (!tie && !winner)
            {
                _board.Draw();
                if (Player == "x")
                {
                    Player = "y";
                }
                else
                {
                    Player = "x";
                }

                _board.SetChoice(Player);
                winner = _board.HasAWinner(_board.GameBoard, Player);
                tie = _board.IsATie(_board.GameBoard, Player);
            }

            if (winner)
            {
                _board.Draw();
                _consoleService.Write($"congrats! The winner is {Player} ");
                _consoleService.Write("wooohooooo!");
            }
            else 
            {
                _consoleService.Write($"It's a draw.");
            }
        }

        public void Reset()
        {
            _board.Reset();
        }
    }
}