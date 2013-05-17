using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth.Tests
{
    public class GameTests
    {
        [TestMethod()]
        public void TryMove()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);
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
            Assert.AreEqual(expected, actual);
        }
        
    }
}
