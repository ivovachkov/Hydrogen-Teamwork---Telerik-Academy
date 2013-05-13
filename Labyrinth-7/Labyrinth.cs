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

        public Labyrinth(Position startPosition)
        {
            if (startPosition == null)
            {
                throw new ArgumentException("The start position cannot be null");
            }

            this.Pos = startPosition;
        }

        public Position Pos
        {
            get { return pos; }
            set { pos = value; }
        }
    
        public bool IsWonWithEscape
        {
            get { return isWonWithEscape; }
            set { isWonWithEscape = value; }
        }

        public void Run(string[,] labyrinth, bool isGameRunning, int x, int y)
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
                        if (labyrinth[x + 1, y] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x + 1, y] = "*";
                            x++;
                            CurrentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (x == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n",
                                CurrentMoves);

                            isGameRunning = false;
                            Console.WriteLine(IsRunning);
                            IsWonWithEscape = true;
                        }

                        Console.WriteLine(Print(labyrinth));
                        break;
                    case "u":
                        if (labyrinth[x - 1, y] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x - 1, y] = "*";
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

                        Console.WriteLine(Print(labyrinth));
                        break;
                    case "r":
                        if (labyrinth[x, y + 1] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x, y + 1] = "*";
                            y++;
                            CurrentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (y == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n",
                                CurrentMoves);

                            isGameRunning = false;
                            IsWonWithEscape = true;
                        }

                        Console.WriteLine(Print(labyrinth));
                        break;
                    case "l":
                        if (labyrinth[x, y - 1] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x, y - 1] = "*";
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
                    case "top":
                        ScoreBoard.Display();
                        Console.WriteLine("\n");
                        Console.WriteLine(Print(labyrinth));
                        break;
                    case "restart":
                        isGameRunning = false;
                        break;
                    case "exit":
                        Console.WriteLine("Good bye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }
        }

        public string Print(string[,] labyrinth)
        {
            // Removing the magic number 7 and swithing it with the number of columns in the labyrinth
            int columnsInLabyrinth = labyrinth.GetLength(0);
            StringBuilder result = new StringBuilder();

            for (int columnIndex = 0; columnIndex < columnsInLabyrinth; columnIndex++)
            {

                for (int index = 0; index < columnsInLabyrinth; index++)
                {
                    result.Append(labyrinth[columnIndex, index]).Append(" ");
                }

                //Because on the next row we have to begin on a new line.
                result.Append("\n");
            }

            return result.ToString();
        }

        public void Generate(string[,] labyrinth, int x, int y)
        {
            // Removed use of the magic number 7 for the number of rows and columns
            int numberOfRows = labyrinth.GetLength(0);
            int numberOfColumns = labyrinth.GetLength(1);

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int column = 0; column < numberOfColumns; column++)
                {
                    labyrinth[row, column] = Convert.ToString(randomNumber.Next(2));
                    if (labyrinth[row, column] == "0")
                    {
                        labyrinth[row, column] = "-";
                    }
                    else
                    {
                        labyrinth[row, column] = "x";
                    }
                }
            }

            labyrinth[pos.X, pos.Y] = "*";
        }

        //The is a posible that at the beginning we are stuck and we can't move.
        public bool IsBlocked(string[,] labyrinth, int rowIndex, int columnIndex)
        {
            bool isTopBlocked = labyrinth[rowIndex - 1, columnIndex] == "x";
            bool isBottomBlocked = labyrinth[rowIndex + 1, columnIndex] == "x";
            bool isLeftBlocked = labyrinth[rowIndex, columnIndex - 1] == "x";
            bool isRightblocked = labyrinth[rowIndex, columnIndex + 1] == "x";
            bool isAbleToMove = isTopBlocked && isBottomBlocked && isLeftBlocked && isRightblocked;

            return isAbleToMove;
        }

        public void SolutionChecker(string[,] labyrinth, int rowIndex, int columnIndex)
        {
            // Added another variable so we don't need to use 1 variable for 2 things 
            // Exctacted method for checking to see if we can move
            bool isBlocked = IsBlocked(labyrinth, rowIndex, columnIndex);
            //isAbleToMove = IsAbleToMove(labyrinth,  rowIndex,  columnIndex);
            bool isAbleToMove = true;
            while (isAbleToMove && !isBlocked)
            {
                try
                {
                    // Extracted Method which checks is the move inside the matrix
                    IsInside(labyrinth, ref rowIndex, ref columnIndex, ref isAbleToMove);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetType());
                    for (int row = 0; row < 7; row++)
                    {
                        for (int column = 0; column < 7; column++)
                        {
                            if (labyrinth[row, column] == "0")
                            {
                                labyrinth[row, column] = "-";
                            }
                        }

                        isAbleToMove = false;
                        isFinished = true;
                    }
                }
            }
        }

        private static void IsInside(string[,] labyrinth, ref int rowIndex,
            ref int columnIndex, ref bool isAbleToMove)
        {
            
            if (labyrinth[rowIndex + 1, columnIndex] == "-")
            {
                labyrinth[rowIndex + 1, columnIndex] = "0";
                rowIndex++;
            }
            else if (labyrinth[rowIndex, columnIndex + 1] == "-")
            {
                labyrinth[rowIndex, columnIndex + 1] = "0";
                columnIndex++;
            }
            else if (labyrinth[rowIndex - 1, columnIndex] == "-")
            {
                labyrinth[rowIndex - 1, columnIndex] = "0";
                rowIndex--;
            }
            else if (labyrinth[rowIndex, columnIndex - 1] == "-")
            {
                labyrinth[rowIndex, columnIndex - 1] = "0";
                columnIndex--;
            }
            else
            {
                isAbleToMove = false;
            }
        }
    }
}