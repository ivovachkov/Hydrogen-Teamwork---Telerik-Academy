using System;
using System.Collections.Generic;

namespace Labyrinth
{
    public class Game
    {
        public static bool flag;

        public static bool flag2;

        public static bool flag3;

        public static bool flag4;

        public static int positionX;

        public static int positionY;

        public static int currentMoves;

        //Added new field for better use of random numberes
        private static readonly Random randomNumber = new Random();

        public static List<Table> Scores = new List<Table>(4);

        protected static void DisplayLabyrinth(string[,] labyrinth)
        {
            //Removing the magic number 7 and swithing it with the number of columns in the labyrinth

            int columnsInLabyrinth = labyrinth.GetLength(0);

            for (int columnIndex = 0; columnIndex < columnsInLabyrinth; columnIndex++)
            {
                string firstElement = labyrinth[columnIndex, 0];
                string secondElement = labyrinth[columnIndex, 1];
                string thirdElement = labyrinth[columnIndex, 2];
                string fourthElement = labyrinth[columnIndex, 3];
                string fifthElement = labyrinth[columnIndex, 4];
                string sixthElement = labyrinth[columnIndex, 5];
                string seventhElement = labyrinth[columnIndex, 6];

                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} ",
                    firstElement, secondElement, thirdElement, fourthElement, fifthElement, sixthElement, seventhElement);
            }

            Console.WriteLine();
        }

        protected static void LabyrinthGenerator(string[,] labyrinth, int x, int y)
        {
            //Removed use of the magic number 7 for the number of rows and columns
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

            labyrinth[positionX, positionY] = "*";
        }

        protected static void SolutionChecker(string[,] labyrinth, int rowIndex, int columnIndex)
        {
            bool isInsideMatrix = true;

            if (labyrinth[rowIndex + 1, columnIndex] == "x" && labyrinth[rowIndex, columnIndex + 1] == "x" 
                && labyrinth[rowIndex - 1, columnIndex] == "x" && labyrinth[rowIndex, columnIndex - 1] == "x")
            {
                isInsideMatrix = false;
            }

            while (isInsideMatrix)
            {
                try
                {
                    //Extracted Method which checks is the move inside the matrix
                    IsInsideLabyrint(labyrinth, ref rowIndex, ref columnIndex, ref isInsideMatrix);
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

                        isInsideMatrix = false;
                        flag = true;
                    }
                }
            }
        }
  
        private static void IsInsideLabyrint(string[,] labyrinth, ref int rowIndex, ref int columnIndex, ref bool isInsideMatrix)
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