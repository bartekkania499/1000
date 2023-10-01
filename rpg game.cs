```csharp
using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }

    class Game
    {
        private Board board;
        private Player currentPlayer;

        public Game()
        {
            board = new Board();
            currentPlayer = Player.X;
        }

        public void Start()
        {
            bool gameOver = false;

            while (!gameOver)
            {
                Console.Clear();
                board.Display();

                Console.WriteLine($"Player {currentPlayer}'s turn. Enter row and column (e.g. 1 2): ");
                string[] input = Console.ReadLine().Split(' ');

                int row = int.Parse(input[0]);
                int col = int.Parse(input[1]);

                if (board.IsValidMove(row, col))
                {
                    board.MakeMove(row, col, currentPlayer);

                    if (board.IsWinningMove(currentPlayer))
                    {
                        Console.Clear();
                        board.Display();
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        gameOver = true;
                    }
                    else if (board.IsBoardFull())
                    {
                        Console.Clear();
                        board.Display();
                        Console.WriteLine("It's a draw!");
                        gameOver = true;
                    }
                    else
                    {
                        currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                    Console.ReadLine();
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    class Board
    {
        private char[,] cells;

        public Board()
        {
            cells = new char[3, 3];
            Initialize();
        }

        private void Initialize()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    cells[row, col] = ' ';
                }
            }
        }

        public void Display()
        {
            Console.WriteLine("  1 2 3");
            for (int row = 0; row < 3; row++)
            {
                Console.Write($"{row + 1} ");
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($"{cells[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        public bool IsValidMove(int row, int col)
        {
            return row >= 0 && row < 3 && col >= 0 && col < 3 && cells[row, col] == ' ';
        }

        public void MakeMove(int row, int col, Player player)
        {
            cells[row, col] = player == Player.X ? 'X' : 'O';
        }

        public bool IsWinningMove(Player player)
        {
            char symbol = player == Player.X ? 'X' : 'O';

            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (cells[row, 0] == symbol && cells[row, 1] == symbol && cells[row, 2] == symbol)
                {
                    return true;
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (cells[0, col] == symbol && cells[1, col] == symbol && cells[2, col] == symbol)
                {
                    return true;
                }
            }

            // Check diagonals
            if (cells[0, 0] == symbol && cells[1, 1] == symbol && cells[2, 2] == symbol)
            {
                return true;
            }

            if (cells[0, 2] == symbol && cells[1, 1] == symbol && cells[2, 0] == symbol)
            {
                return true;
            }

            return false;
        }

        public bool IsBoardFull()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (cells[row, col] == ' ')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    enum Player
    {
        X,
        O
    }
}
```
