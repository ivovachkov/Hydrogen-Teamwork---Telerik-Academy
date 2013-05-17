using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    public class Labyrinth : Game
    {
        public const int LabyrinthSize = 7;

        private readonly Random randomNumber = new Random();
        private bool isWonWithEscape;
        private PlayerPosition position = new PlayerPosition();
        private ScoreBoard scoreBoard = new ScoreBoard();
        private readonly Cell[,] board = new Cell[LabyrinthSize, LabyrinthSize];

        public Labyrinth(PlayerPosition startPosition)
        {
            if (startPosition == null)
            {
                throw new ArgumentNullException("The start position cannot be null");
            }

            this.Position = startPosition;
        }

        #region Properties

        public bool IsWonWithEscape
        {
            get
            {
                return this.isWonWithEscape;
            }
            set
            {
                this.isWonWithEscape = value;
            }
        }

        public PlayerPosition Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        public ScoreBoard ScoreBoard
        {
            get
            {
                return this.scoreBoard;
            }
            set
            {
                this.scoreBoard = value;
            }
        }

        public Cell[,] Board
        {
            get
            {
                return this.Clone();
            }
        }

        #endregion

        #region Methods

        public void StartGame()
        {
            this.IsRunning = true;

            Console.WriteLine(Message.Welcome);

            while (true)
            {
               // this.IsGenerationDone = false;
                this.IsWonWithEscape = false;

                //while (!this.IsGenerationDone)
                while(true)
                {
                    this.Generate();

                    if (this.ExitPathAvailable())
                    {
                        break;
                    }
                }

                Console.WriteLine(this);
                this.Run(this.Position.X, this.Position.Y);

                if (this.IsWonWithEscape)
                {
                    Console.Write("Please enter your name: ");
                    string name = Console.ReadLine();
                    this.ScoreBoard.AddNewScore(this.CurrentMoves, name);
                    this.isRunning = true;
                }
                else if (!this.isRunning)
                {
                    break;
                }
            }
        }

        private void Run(int x, int y)
        {
            this.CurrentMoves = 0;

            while (this.IsRunning)
            {
                Console.Write(Message.ValidCommands);
                string moveDirection = Console.ReadLine().ToLower();

                switch (moveDirection)
                {
                    case "d":
                        ProcessMoveDown(ref x, y);
                        //Console.WriteLine(this);
                        break;
                    case "u":
                        ProcessMoveUp(ref x, y);
                        //Console.WriteLine(this);
                        break;
                    case "r":
                        ProcessMoveRight(x, ref y);
                        //Console.WriteLine(this);
                        break;
                    case "l":
                        ProcessMoveLeft(x, ref y);
                        //Console.WriteLine(this);
                        break;
                    case "top":
                        Console.WriteLine(this.ScoreBoard);
                        //Console.WriteLine(this);
                        break;
                    case "restart":
                        return;
                    case "exit":
                        Console.WriteLine(Message.GoodBye);
                        this.isRunning = false;
                        return;
                    default:
                        Console.WriteLine(Message.InvalidCommand);
                        break;
                }

                Console.WriteLine(this);
            }
        }
 
        private void ProcessMoveLeft(int x, ref int y)
        {
            if (this.board[x, y - 1].Value == '-')
            {
                this.board[x, y].Value = '-';
                this.board[x, y - 1].Value = '*';
                y--;
                this.CurrentMoves++;
            }
            else
            {
                Console.WriteLine(Message.InvalidMove);
            }

            if (y == 0)
            {
                Console.WriteLine(Message.Congratulations, CurrentMoves);
                this.IsRunning = false;
                this.IsWonWithEscape = true;
            }
        }
      
        private void ProcessMoveRight(int x, ref int y)
        {
            if (this.board[x, y + 1].Value == '-')
            {
                this.board[x, y].Value = '-';
                this.board[x, y + 1].Value = '*';
                y++;
                this.CurrentMoves++;
            }
            else
            {
                Console.WriteLine(Message.InvalidMove);
            }

            if (y == LabyrinthSize - 1)
            {
                Console.WriteLine(Message.Congratulations, this.CurrentMoves);
                this.IsRunning = false;
                this.IsWonWithEscape = true;
            }
        }

        private void ProcessMoveUp(ref int x, int y)
        {
            if (this.board[x - 1, y].Value == '-')
            {
                this.board[x, y].Value = '-';
                this.board[x - 1, y].Value = '*';
                x--;
                this.CurrentMoves++;
            }
            else
            {
                Console.WriteLine(Message.InvalidMove);
            }

            if (x == 0)
            {
                Console.WriteLine(Message.Congratulations, CurrentMoves);
                this.IsRunning = false;
                this.IsWonWithEscape = true;
            }
        }

        private void ProcessMoveDown(ref int x, int y)
        {
            if (this.board[x + 1, y].Value == '-')
            {
                this.board[x, y].Value = '-';
                this.board[x + 1, y].Value = '*';
                x++;
                CurrentMoves++;
            }
            else
            {
                Console.WriteLine(Message.InvalidMove);
            }

            if (x == LabyrinthSize - 1)
            {
                Console.WriteLine(Message.Congratulations, CurrentMoves);
                this.IsRunning = false;
                this.IsWonWithEscape = true;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < this.board.GetLength(0); row++)
            {
                for (int col = 0; col < this.board.GetLength(1); col++)
                {
                    result.Append(this.board[row, col].Value).Append(" ");
                }
                result.AppendLine();
            }

            return result.ToString();
        }

        public Cell[,] Generate()
        {
            for (int row = 0; row < this.board.GetLength(0); row++)
            {
                for (int column = 0; column < this.board.GetLength(1); column++)
                {
                    int randomValue = randomNumber.Next(4);
                    if (randomValue == 0)
                    {
                        this.board[row, column] = new Cell(row, column, '-');
                    }
                    else
                    {
                        this.board[row, column] = new Cell(row, column, 'x');
                    }
                }
            }

            this.board[this.Position.X, this.Position.Y].Value = '*';

            return this.Clone();
        }

        private bool IsOnBorder(int rowIndex, int columnIndex)
        {
            if (rowIndex == 0 || rowIndex == LabyrinthSize - 1)
            {
                return true;
            }
            else if (columnIndex == 0 || columnIndex == LabyrinthSize - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void VisitCell(Cell[,] labyrinth, Queue<Cell> visitedCells, int row, int column)
        {
            if (labyrinth[row, column].Value == Cell.Empty || labyrinth[row, column].Value == Cell.Player)
            {
                labyrinth[row, column].Value = Cell.Block;
                visitedCells.Enqueue(labyrinth[row, column]);
            }
        }

        private bool ExitPathAvailable()
        {
            if (this.Position == null)
            {
                throw new ArgumentException("The value of the start cell cannot be null");
            }

            Queue<Cell> visitedCells = new Queue<Cell>();
            Cell[,] clonedLabyrinth = this.Clone();

            this.VisitCell(clonedLabyrinth, visitedCells, this.Position.X, this.Position.Y);

            while (visitedCells.Count > 0)
            {
                Cell currentCell = visitedCells.Dequeue();
                int row = currentCell.Row;
                int column = currentCell.Column;

                if (this.IsOnBorder(row, column))
                {
                    return true;
                }

                // We are visiting each of the neighbours of the current cell.
                VisitCell(clonedLabyrinth, visitedCells, row, column + 1);
                VisitCell(clonedLabyrinth, visitedCells, row, column - 1);
                VisitCell(clonedLabyrinth, visitedCells, row + 1, column);
                VisitCell(clonedLabyrinth, visitedCells, row - 1, column);
            }

            return false;
        }

        public Cell[,] Clone()
        {
            Cell[,] cloned = new Cell[LabyrinthSize, LabyrinthSize];

            for (int row = 0; row < LabyrinthSize; row++)
            {
                for (int column = 0; column < LabyrinthSize; column++)
                {
                    cloned[row, column] = this.board[row, column].Clone() as Cell;
                }
            }

            return cloned;
        }

        #endregion
    }
}