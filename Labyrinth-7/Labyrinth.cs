using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    public class Labyrinth : Game
    {
        public const int LabyrinthSize = 7;

        // Added new field for better use of random numberes
        private static readonly Random randomNumber = new Random();
      
        public static void AddNewScore(List<Table> scores, int moves)
        {
            if (scores.Count != 0)
            {
                scores.Sort(delegate(Table firstScore, Table secondScore)
                {
                    return firstScore.Moves.CompareTo(secondScore.Moves);
                });
            }

            if (scores.Count == 5)
            {
                if (scores[4].Moves > moves)
                {
                    scores.Remove(scores[4]);
                    Console.WriteLine("Please enter your nickname");
                    string name = Console.ReadLine();
                    scores.Add(new Table(moves, name));
                    UpdateScoreSheet(scores);
                }
            }
            if (scores.Count < 5)
            {
                Console.WriteLine("Please enter your nickname");
                string name = Console.ReadLine();
                scores.Add(new Table(moves, name));
                UpdateScoreSheet(scores);
            }

            Game.IsWonWithEscape = false;
        }

        public static void UpdateScoreSheet(List<Table> scores)
        {
            Console.WriteLine("\n");
            if (scores.Count == 0)
            {
                Console.WriteLine("The scoreboard is empty! ");
            }
            else
            {
                int rankPosition = 1;
                scores.Sort(
                    delegate(Table firstScore, Table secondScore)
                    {
                        return firstScore.Moves.CompareTo(secondScore.Moves);
                    }
                );
                Console.WriteLine("Top 5: \n");

                scores.ForEach(
                    delegate(Table score)
                    {
                        Console.WriteLine(String.Format(rankPosition + ". {1} ---> {0} moves", score.Moves, score.Name));
                        rankPosition++;
                    }
                );

                Console.WriteLine("\n");
            }
        }

        public static void Test(string[,] labyrinth, bool isGameRunning, int moveCount, int y)
        {
            Game.CurrentMoves = 0;

            while (isGameRunning)
            {
                Console.Write("\nEnter your move (L=left, R=right, D=down, U=up): ");
                string moveDirrection = string.Empty;
                moveDirrection = Console.ReadLine();

                // Removed the need to check for uppercase or lowercase
                switch (moveDirrection.ToLower())
                {
                    case "d":
                        if (labyrinth[moveCount + 1, y] == "-")
                        {
                            labyrinth[moveCount, y] = "-";
                            labyrinth[moveCount + 1, y] = "*";
                            moveCount++;
                            Game.CurrentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (moveCount == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n",
                                Game.CurrentMoves);

                            isGameRunning = false;
                            Console.WriteLine( Game.IsRunning);
                            IsWonWithEscape = true;
                        }

                        PrintLabyrinth(labyrinth);
                        break;
                    case "u":
                        if (labyrinth[moveCount - 1, y] == "-")
                        {
                            labyrinth[moveCount, y] = "-";
                            labyrinth[moveCount - 1, y] = "*";
                            moveCount--;
                            Game.CurrentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (moveCount == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", 
                                Game.CurrentMoves);
                            isGameRunning = false;
                            IsWonWithEscape = true;
                        }

                        PrintLabyrinth(labyrinth);
                        break;
                    case "r":

                        if (labyrinth[moveCount, y + 1] == "-")
                        {
                            labyrinth[moveCount, y] = "-";
                            labyrinth[moveCount, y + 1] = "*";
                            y++;
                            Game.CurrentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (y == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n",
                                Game.CurrentMoves);

                            isGameRunning = false;
                            IsWonWithEscape = true;
                        }

                        PrintLabyrinth(labyrinth);
                        break;
                    case "l":

                        if (labyrinth[moveCount, y - 1] == "-")
                        {
                            labyrinth[moveCount, y] = "-";
                            labyrinth[moveCount, y - 1] = "*";
                            y--;
                            Game.CurrentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (y == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", 
                                Game.CurrentMoves);

                            isGameRunning = false;
                            IsWonWithEscape = true;
                        }

                        PrintLabyrinth(labyrinth);
                        break;                  
                    case "top":
                        UpdateScoreSheet(Scores);
                        Console.WriteLine("\n");
                        PrintLabyrinth(labyrinth);
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

        public static void PrintLabyrinth(string[,] labyrinth)
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

            Console.WriteLine(result);
        }

        public static void LabyrinthGenerator(string[,] labyrinth, int x, int y)
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
        public static bool IsBlocked(string[,] labyrinth, int rowIndex, int columnIndex)
        {
            bool isTopBlocked = labyrinth[rowIndex - 1, columnIndex] == "x";
            bool isBottomBlocked = labyrinth[rowIndex + 1, columnIndex] == "x";
            bool isLeftBlocked = labyrinth[rowIndex, columnIndex - 1] == "x";
            bool isRightblocked = labyrinth[rowIndex, columnIndex + 1] == "x";
            bool isAbleToMove = isTopBlocked && isBottomBlocked && isLeftBlocked && isRightblocked;

            return isAbleToMove;
        }

        public static void SolutionChecker(string[,] labyrinth, int rowIndex, int columnIndex)
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
                    IsInsideLabyrint(labyrinth, ref rowIndex, ref columnIndex, ref isAbleToMove);
                }
                catch (Exception)
                {
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

        private static void IsInsideLabyrint(string[,] labyrinth, ref int rowIndex,
            ref int columnIndex, ref bool isInsideMatrix)
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
                isInsideMatrix = false;
            }
        }
    }
}