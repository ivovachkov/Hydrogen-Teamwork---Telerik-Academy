using System;
using System.IO;

namespace Labyrinth
{
    public class LabyrinthDemo
    {
        public static Cell[,] LabyrinthDataFromStringArray(string[] rawData)
        {
            Cell[,] result = new Cell[Labyrinth.LabyrinthSize, Labyrinth.LabyrinthSize];

            for (int row = 0; row < Labyrinth.LabyrinthSize; row++)
            {
                for (int column = 0; column < Labyrinth.LabyrinthSize; column++)
                {
                    result[row, column] = new Cell(row, column, rawData[row][column]);
                }
            }

            return result;
        }

        static void Main()
        {

            //PlayerPosition startPosition = new PlayerPosition(3, 3);

            //string[] rawData = new string[Labyrinth.LabyrinthSize]
            //{
            //    "XXXXXXX",
            //    "X-X---X",
            //    "X---X-X",
            //    "X--*--X",
            //    "X-X----",
            //    "X-----X",
            //    "XXXXXXX"
            //};

            //Cell[,] board = LabyrinthDataFromStringArray(rawData);


            //Labyrinth labyrinth = new Labyrinth(startPosition, board);

            //StreamWriter writer = new StreamWriter("../../displayMessage.txt");

            //string result = labyrinth.ToString();
            //using (writer)
            //{
            //    writer.WriteLine(result);             
            //}

            //Console.WriteLine(labyrinth);

            PlayerPosition startPosition = new PlayerPosition(3, 3);
            Labyrinth labyrinth = new Labyrinth(startPosition);
            labyrinth.StartGame();
        }
    }
}