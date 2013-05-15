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
        private Position pos = new Position();
        private ScoreBoard scoreBoard = new ScoreBoard();

        private Cell[,] board = new Cell[LabyrinthSize, LabyrinthSize];

        public Labyrinth(Position startPosition)
        {
            if (startPosition == null)
            {
                throw new ArgumentNullException("The start position cannot be null");
            }

            this.Pos = startPosition;
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

        public Position Pos
        {
            get
            {
                return pos;
            }
            set
            {
                pos = value;
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

        public void Run(Cell[,] labyrinth, bool isGameRunning, int x, int y)
        {
            CurrentMoves = 0;

            while (isGameRunning)
            {
                Console.Write("\nEnter your move (L=left, R=right, D=down, U=up): ");
                string moveDirrection = Console.ReadLine();

                // Removed the need to check for uppercase or lowercase
                switch (moveDirrection.ToLower())
                {
                    case "d":
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
                                Console.WriteLine("\nInvalid move! \n ");
                            }

                            // changed the magic number 6 -> LabyrinthSize - 1
                            if (x == LabyrinthSize - 1)
                            {
                                Console.WriteLine("\nCongratulations you escaped with {0} moves.\n",
                                    CurrentMoves);

                                isGameRunning = false;
                                IsWonWithEscape = true;
                            }

                            Console.WriteLine(Print(labyrinth));
                            break;
                        }
                    case "u":
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
                                Console.WriteLine("\nInvalid move! \n ");
                            }

                            if (x == 0)
                            {
                                Console.WriteLine("\nCongratulations you escaped with {0} moves.\n",
                                    CurrentMoves);
                                isGameRunning = false;
                                IsWonWithEscape = true;
                            }
                        }

                        Console.WriteLine(Print(labyrinth));
                        break;
                    case "r":
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
                                Console.WriteLine("\nInvalid move! \n ");
                            }

                            // changed the magic number 6 -> LabyrinthSize - 1
                            if (y == LabyrinthSize - 1)
                            {
                                Console.WriteLine("\nCongratulations you escaped with {0} moves.\n",
                                    CurrentMoves);

                                isGameRunning = false;
                                IsWonWithEscape = true;
                            }

                            Console.WriteLine(Print(labyrinth));
                            break;
                        }
                    case "l":
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
                                Console.WriteLine("\nInvalid move! \n ");
                            }

                            if (y == 0)
                            {
                                Console.WriteLine("\nCongratulations you escaped with {0} moves.\n",
                                    CurrentMoves);

                                isGameRunning = false;
                                IsWonWithEscape = true;
                            }

                            Console.WriteLine(Print(labyrinth));
                            break;
                        }
                    case "top":
                        {
                            Console.WriteLine(this.ScoreBoard);
                            Console.WriteLine(Print(labyrinth));
                            break;
                        }
                    case "restart":
                        {
                            isGameRunning = false;
                            break;
                        }
                    case "exit":
                        {
                            Console.WriteLine("Good bye!");
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid command!");
                            break;
                        }
                }
            }
        }

        public string Print(Cell[,] labyrinth)
        {
            // Removing the magic number 7 and swithing it with the number of columns in the labyrinth
            int columnsInLabyrinth = labyrinth.GetLength(0);
            StringBuilder result = new StringBuilder();

            for (int columnIndex = 0; columnIndex < columnsInLabyrinth; columnIndex++)
            {
                for (int index = 0; index < columnsInLabyrinth; index++)
                {
                    result.Append(labyrinth[columnIndex, index].Value).Append(" ");
                }

                //Because on the next row we have to begin on a new line.
                result.Append("\n");
            }

            return result.ToString();
        }

        // changed return type for easy testing
        public Cell[,] Generate(Cell[,] labyrinth, int x, int y)
        {
            // Removed use of the magic number 7 for the number of rows and columns
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

            labyrinth[pos.X, pos.Y].Value = '*';

            return labyrinth;
        }

        //The is a posible that at the beginning we are stuck and we can't move.
        public bool IsBlocked(Cell[,] labyrinth, int rowIndex, int columnIndex)
        {
            bool isTopBlocked = labyrinth[rowIndex - 1, columnIndex].Value == 'x';
            bool isBottomBlocked = labyrinth[rowIndex + 1, columnIndex].Value == 'x';
            bool isLeftBlocked = labyrinth[rowIndex, columnIndex - 1].Value == 'x';
            bool isRightblocked = labyrinth[rowIndex, columnIndex + 1].Value == 'x';
            //renamed isAbleToMove -> isBlocked
            bool isBlocked = isTopBlocked && isBottomBlocked && isLeftBlocked && isRightblocked;
            
            return isBlocked;
        }

        public void SolutionChecker(Cell[,] labyrinth, int rowIndex, int columnIndex)
        {
            // Added another variable so we don't need to use 1 variable for 2 things 
            // Exctacted method for checking to see if we can move
            bool isBlocked = IsBlocked(labyrinth, rowIndex, columnIndex);
            //isAbleToMove = IsAbleToMove(labyrinth,  rowIndex,  columnIndex);
            bool isAbleToMove = true;
            while (isAbleToMove && !isBlocked)
            {
                // Removed try-catch block
                // Extracted Method which checks is the move inside the matrix
                IsInside(labyrinth, ref rowIndex, ref columnIndex, ref isAbleToMove);
                
                for (int row = 0; row < labyrinth.GetLength(0); row++)
                {
                    for (int column = 0; column < labyrinth.GetLength(1); column++)
                    {
                        if (labyrinth[row, column].Value == '0')
                        {
                            labyrinth[row, column].Value = Cell.Empty;
                        }
                    }
                }
                // Moved both outside, no need to be inside the loop
                isAbleToMove = false;
                isFinished = true;
            }
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
            if (this.pos == null)
            {
                throw new ArgumentException("The value of the start cell cannot be null"); 
            }

            Queue<Cell> visitedCells = new Queue<Cell>();
            Cell[,] clonedLabyrinth = this.Clone(labyrinth);
            this.VisitCell(clonedLabyrinth, visitedCells, this.Pos.X, this.Pos.Y);

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