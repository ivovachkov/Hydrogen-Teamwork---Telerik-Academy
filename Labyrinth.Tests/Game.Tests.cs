using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth.Tests
{
<<<<<<< HEAD
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestMethod()
        {

        }
    }
}
=======
    [TestClass()]
    public class GameTest
    {
        [TestMethod()]
        public void TryMove()
        {
            
            Position startPosition = new Position(3, 3);
            Labyrinth labyrinth = new Labyrinth(startPosition);
            Cell[,] labyrinthBoard = new Cell[Labyrinth.LabyrinthSize, Labyrinth.LabyrinthSize];
            labyrinth.IsRunning = true;
            
            string[] rawData = new string[Labyrinth.LabyrinthSize]
                                       {
                                           "-xxxx--",
                                           "xxxx--x",
                                           "xx---x-",
                                           "x-x*x-x",
                                           "xxxxxxx",
                                           "xxx-xxx",
                                           "xxx-xx-"
                                       };
            string moveDirrection = "d";
            string expected = "Invalid move!";
            string actual = "";
            actual = "";
            Assert.AreEqual(expected, actual);
        }
        
    }
}
>>>>>>> 11d3e3465cdf1ca408b205f69d71e7ca6afd8d2e
