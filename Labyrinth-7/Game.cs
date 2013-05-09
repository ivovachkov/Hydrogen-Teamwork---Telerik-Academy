using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    public class Game
    {
        public static bool isFinished;

        public static bool isRunning;

        public static bool isWonWithEscape;

        public static Position position = new Position();

       // public static int positionX;

       // public static int positionY;

        private static int currentMoves;

        // Added new field for better use of random numberes
        private static readonly Random randomNumber = new Random();

        public static List<Table> Scores = new List<Table>(4);

        public static Position Position
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

        public static int CurrentMoves
        {
            get
            {
                return currentMoves;
            }

            protected set
            {
                currentMoves = value;
            }
        }

        protected static void PrintLabyrinth(string[,] labyrinth)
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

        protected static void LabyrinthGenerator(string[,] labyrinth, int x, int y)
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

            labyrinth[position.X, position.Y] = "*";
        }

        protected static void SolutionChecker(string[,] labyrinth, int rowIndex, int columnIndex)
        {
            bool isAbleToMove = true;

            if (labyrinth[rowIndex + 1, columnIndex] == "x" && labyrinth[rowIndex, columnIndex + 1] == "x" 
                && labyrinth[rowIndex - 1, columnIndex] == "x" && labyrinth[rowIndex, columnIndex - 1] == "x")
            {
                isAbleToMove = false;
            }

            while (isAbleToMove)
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