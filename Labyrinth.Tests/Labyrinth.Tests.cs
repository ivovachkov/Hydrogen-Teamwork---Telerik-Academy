using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth.Tests
{
    [TestClass]
    public class LabyrinthTests
    {
        public Cell[,] LabyrinthDataFromStringArray(string[] rawData)
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "The start position cannot be null")]
        public void Position_NullValue()
        {
            PlayerPosition startPosition = new PlayerPosition();
            startPosition = null;
            Labyrinth labyrinth = new Labyrinth(startPosition);
        }

        [TestMethod]
        public void IsOnBoarderTest()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);

            Labyrinth labyrinth = new Labyrinth(startPosition);

            var privateObject = new PrivateObject(labyrinth);

            var actual = privateObject.Invoke("IsOnBorder", 6, 6);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void IsGameWonTestTrue()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);

            Labyrinth labyrinth = new Labyrinth(startPosition);

            var privateObject = new PrivateObject(labyrinth);

            var actual = privateObject.Invoke("IsGameWon", 6, 6);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void IsGameWonTestFalse()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);

            Labyrinth labyrinth = new Labyrinth(startPosition);

            var privateObject = new PrivateObject(labyrinth);

            var actual = privateObject.Invoke("IsGameWon", 3, 3);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void LabyrinthMoveUpTest()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);

            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X----",
                "X-----X",
                "XXXXXXX"
            };

            Cell[,] board = LabyrinthDataFromStringArray(rawData);

            Labyrinth labyrinth = new Labyrinth(startPosition, board);

            var privateObject = new PrivateObject(labyrinth);

            privateObject.Invoke("ProcessMoveUp", 3, 3);

            string result =
                @"X X X X X X X 
X - X - - - X 
X - - * X - X 
X - - - - - X 
X - X - - - - 
X - - - - - X 
X X X X X X X 
";
            string expected = labyrinth.ToString();
            Assert.AreEqual(expected, result);                       
        }

        [TestMethod]
        public void LabyrinthMoveDownTest()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);

            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X----",
                "X-----X",
                "XXXXXXX"
            };

            Cell[,] board = LabyrinthDataFromStringArray(rawData);

            Labyrinth labyrinth = new Labyrinth(startPosition, board);

            var privateObject = new PrivateObject(labyrinth);

            privateObject.Invoke("ProcessMoveDown", 3, 3);

            string result =
                @"X X X X X X X 
X - X - - - X 
X - - - X - X 
X - - - - - X 
X - X * - - - 
X - - - - - X 
X X X X X X X 
";
            string expected = labyrinth.ToString();
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void LabyrinthMoveLeftTest()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);

            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X----",
                "X-----X",
                "XXXXXXX"
            };

            Cell[,] board = LabyrinthDataFromStringArray(rawData);

            Labyrinth labyrinth = new Labyrinth(startPosition, board);

            var privateObject = new PrivateObject(labyrinth);

            privateObject.Invoke("ProcessMoveLeft", 3, 3);

            string result =
                @"X X X X X X X 
X - X - - - X 
X - - - X - X 
X - * - - - X 
X - X - - - - 
X - - - - - X 
X X X X X X X 
";
            string expected = labyrinth.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LabyrinthMoveUpRight()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);

            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X----",
                "X-----X",
                "XXXXXXX"
            };

            Cell[,] board = LabyrinthDataFromStringArray(rawData);

            Labyrinth labyrinth = new Labyrinth(startPosition, board);

            var privateObject = new PrivateObject(labyrinth);

            privateObject.Invoke("ProcessMoveRight", 3, 3);

            string result =
                @"X X X X X X X 
X - X - - - X 
X - - - X - X 
X - - - * - X 
X - X - - - - 
X - - - - - X 
X X X X X X X 
";
            string expected = labyrinth.ToString();
            Assert.AreEqual(expected, result);
        }

    }
}
