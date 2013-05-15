using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth.Tests
{
    [TestClass]
    public class ScoreBoardTests
    {
        [TestMethod]
        public void AddNewScoreTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddNewScore(4, "Pesho");
            scoreBoard.AddNewScore(7, "Gosho");
            scoreBoard.AddNewScore(5, "Dragan");
            string actual = scoreBoard.ToString();
            string expected = "\nTop 5:\n\n1. Pesho ---> 4 moves\n2. Dragan ---> 5 moves\n3. Gosho ---> 7 moves\n\n\n";

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            Assert.AreEqual(expected, actual);
=======
            Assert.AreEqual(3, scores.Count);           
>>>>>>> f3ed1eaa00561d4a34de5f31485b687206d5aca7
=======
            Assert.AreEqual(3, scores.Count);           
>>>>>>> f3ed1eaa00561d4a34de5f31485b687206d5aca7
=======
            Assert.AreEqual(3, scores.Count);           
>>>>>>> f3ed1eaa00561d4a34de5f31485b687206d5aca7
=======
            Assert.AreEqual(3, scores.Count);           
>>>>>>> f3ed1eaa00561d4a34de5f31485b687206d5aca7
        }
    }
}
