using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    class Game
    {
        public static bool flag;

        public static bool flag2;

        public static bool flag3;

        public static bool flag4;

        public static int positionX;

        public static int positionY;

        public static int currentMoves;

        public static List<Table> Scores = new List<Table>(4);

        protected static void DisplayLabyrinth(string[,] labyrinth)
        {
            for (int columnIndex = 0; columnIndex < 7; columnIndex++)
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
            Random randomInt = new Random();

            for (int row = 0; row < 7; row++)
            {
                for (int column = 0; column < 7; column++)
                {
                    labyrinth[row, column] = Convert.ToString(randomInt.Next(2));
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
    }
}