using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    public class Labyrinth : Game
    {
        public const int LabyrinthSize = 7;

        // Added new field for better use of random numberes
        private readonly Random randomNumber = new Random();
        private bool isWonWithEscape;
        private PlayerPosition position = new PlayerPosition();
        private ScoreBoard scoreBoard = new ScoreBoard();

        private Cell[,] board = new Cell[LabyrinthSize, LabyrinthSize];

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
                return isWonWithEscape;
            }
            set
            {
                isWonWithEscape = value;
            }
        }

        public PlayerPosition Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
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

        #endregion

        #region Methods

        public void StartGame()
        {
            //PlayerPosition startPosition = new PlayerPosition(3, 3);
            //Labyrinth labyrinth = new Labyrinth(startPosition);
            Cell[,] labyrinthBoard = new Cell[Labyrinth.LabyrinthSize, Labyrinth.LabyrinthSize];
            this.IsRunning = true;

            Console.WriteLine(Message.Welcome);

            while (true)
            {
                this.IsGenerationDone = false;
                this.IsWonWithEscape = false;

                while (!this.IsGenerationDone)
                {
                    this.Generate(labyrinthBoard, this.Position.X, this.Position.Y);
                    //labyrinth.SolutionChecker(labyrinthBoard, labyrinth.Pos.X, labyrinth.Pos.Y);

                    if (this.ExitPathAvailable(labyrinthBoard))
                    {
                        break;
                    }
                }

                Console.WriteLine(this.Print(labyrinthBoard));
                this.Run(labyrinthBoard, this.IsRunning, this.Position.X, this.Position.Y);

                //used for adding score only when game is finished naturally and not by the restart command.
                if (this.IsWonWithEscape)
                {
                    Console.Write("Please enter your name: ");
                    string name = Console.ReadLine();
                    this.ScoreBoard.AddNewScore(this.CurrentMoves, name);
                }
            }
        }

        public void Run(Cell[,] labyrinth, bool isGameRunning, int x, int y)
        {
            CurrentMoves = 0;

            while (isGameRunning)
            {
                Console.Write(Message.ValidCommands);
                string moveDirection = Console.ReadLine();

                // Removed the need to check for uppercase or lowercase
                switch (moveDirection.ToLower())
                {
                    case "d":
                        ProcessMoveDown(labyrinth, ref isGameRunning, ref x, y);
                        Console.WriteLine(Print(labyrinth));
                        break;
                    case "u":
                        ProcessMoveUp(labyrinth, ref isGameRunning, ref x, y);
                        Console.WriteLine(Print(labyrinth));
                        break;
                    case "r":
                        ProcessMoveRight(labyrinth, ref isGameRunning, x, ref y);
                        Console.WriteLine(Print(labyrinth));
                        break;
                    case "l":
                        ProcessMoveLeft(labyrinth, ref isGameRunning, x, ref y);
                        Console.WriteLine(Print(labyrinth));
                        break;
                    case "top":
                        Console.WriteLine(this.ScoreBoard);
                        Console.WriteLine(Print(labyrinth));
                        break;
                    case "restart":
                        isGameRunning = false;
                        break;
                    case "exit":
                        Console.WriteLine(Message.GoodBye);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(Message.InvalidCommand);
                        break;
                }
            }
        }

        private void ProcessMoveLeft(Cell[,] labyrinth, ref bool isGameRunning, int x, ref int y)
        {
            if (labyrinth[x, y - 1].Value == '-')
            {
                labyrinth[x, y].Value = '-';
                labyrinth[x, y - 1].Value = '*';
                y--;
                CurrentMoves++;
            }
            else
            {
                Console.WriteLine(Message.InvalidMove);
            }

            if (y == 0)
            {
                Console.WriteLine(Message.Congratulations, CurrentMoves);
                isGameRunning = false;
                IsWonWithEscape = true;
            }
        }

        private void ProcessMoveRight(Cell[,] labyrinth, ref bool isGameRunning, int x, ref int y)
        {
            if (labyrinth[x, y + 1].Value == '-')
            {
                labyrinth[x, y].Value = '-';
                labyrinth[x, y + 1].Value = '*';
                y++;
                CurrentMoves++;
            }
            else
            {
                Console.WriteLine(Message.InvalidMove);
            }

            if (y == LabyrinthSize - 1)
            {
                Console.WriteLine(Message.Congratulations, CurrentMoves);
                isGameRunning = false;
                IsWonWithEscape = true;
            }
        }

        private void ProcessMoveUp(Cell[,] labyrinth, ref bool isGameRunning, ref int x, int y)
        {
            if (labyrinth[x - 1, y].Value == '-')
            {
                labyrinth[x, y].Value = '-';
                labyrinth[x - 1, y].Value = '*';
                x--;
                CurrentMoves++;
            }
            else
            {
                Console.WriteLine(Message.InvalidMove);
            }

            if (x == 0)
            {
                Console.WriteLine(Message.Congratulations, CurrentMoves);
                isGameRunning = false;
                IsWonWithEscape = true;
            }
        }

        private void ProcessMoveDown(Cell[,] labyrinth, ref bool isGameRunning, ref int x, int y)
        {
            if (labyrinth[x + 1, y].Value == '-')
            {
                labyrinth[x, y].Value = '-';
                labyrinth[x + 1, y].Value = '*';
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
                isGameRunning = false;
                IsWonWithEscape = true;
            }
        }

        public string Print(Cell[,] labyrinth)
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    result.Append(labyrinth[row, col].Value).Append(" ");
                }
                result.AppendLine();
            }

            return result.ToString();
        }

        // changed return type for easy testing
        public Cell[,] Generate(Cell[,] labyrinth, int x, int y)
        {
            int numberOfRows = labyrinth.GetLength(0);
            int numberOfColumns = labyrinth.GetLength(1);

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int column = 0; column < numberOfColumns; column++)
                {
                    int randomValue = randomNumber.Next(4);
                    if (randomValue == 0)
                    {
                        labyrinth[row, column] = new Cell(row, column, '-');
                    }
                    else
                    {
                        labyrinth[row, column] = new Cell(row, column, 'x');
                    }
                }
            }

            labyrinth[position.X, position.Y].Value = '*';

            return labyrinth;
        }

        //The is a posible that at the beginning we are stuck and we can't move.
        public bool IsBlocked(Cell[,] labyrinth, int rowIndex, int columnIndex)
        {
            bool isTopBlocked = labyrinth[rowIndex - 1, columnIndex].Value == 'x';
            bool isBottomBlocked = labyrinth[rowIndex + 1, columnIndex].Value == 'x';
            bool isLeftBlocked = labyrinth[rowIndex, columnIndex - 1].Value == 'x';
            bool isRightblocked = labyrinth[rowIndex, columnIndex + 1].Value == 'x';
            bool isBlocked = isTopBlocked && isBottomBlocked && isLeftBlocked && isRightblocked;

            return isBlocked;
        }

        public bool IsOnBoarder(int rowIndex, int columnIndex)
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

        public bool ExitPathAvailable(Cell[,] labyrinth)
        {
            if (this.Position == null)
            {
                throw new ArgumentException("The value of the start cell cannot be null");
            }

            Queue<Cell> visitedCells = new Queue<Cell>();
            Cell[,] clonedLabyrinth = this.Clone(labyrinth);

            this.VisitCell(clonedLabyrinth, visitedCells, this.Position.X, this.Position.Y);

            while (visitedCells.Count > 0)
            {
                Cell currentCell = visitedCells.Dequeue();
                int row = currentCell.Row;
                int column = currentCell.Column;

                if (this.IsOnBoarder(row, column))
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

        private static void IsInside(Cell[,] labyrinth, ref int rowIndex,
            ref int columnIndex, ref bool isAbleToMove)
        {
            if (labyrinth[rowIndex + 1, columnIndex].Value == '-')
            {
                labyrinth[rowIndex + 1, columnIndex].Value = '0';
                rowIndex++;
            }
            else if (labyrinth[rowIndex, columnIndex + 1].Value == '-')
            {
                labyrinth[rowIndex, columnIndex + 1].Value = '0';
                columnIndex++;
            }
            else if (labyrinth[rowIndex - 1, columnIndex].Value == '-')
            {
                labyrinth[rowIndex - 1, columnIndex].Value = '0';
                rowIndex--;
            }
            else if (labyrinth[rowIndex, columnIndex - 1].Value == '-')
            {
                labyrinth[rowIndex, columnIndex - 1].Value = '0';
                columnIndex--;
            }
            else
            {
                isAbleToMove = false;
            }
        }

        // ToDo make it a part of the labyrinth board copy
        public Cell[,] Clone(Cell[,] labyrinth)
        {
            Cell[,] cloned = new Cell[LabyrinthSize, LabyrinthSize];

            for (int row = 0; row < LabyrinthSize; row++)
            {
                for (int column = 0; column < LabyrinthSize; column++)
                {
                    cloned[row, column] = labyrinth[row, column].Clone() as Cell;
                }
            }

            return cloned;
        }

        #endregion
    }
}