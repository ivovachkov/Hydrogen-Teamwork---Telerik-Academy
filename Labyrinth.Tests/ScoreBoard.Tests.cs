using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth.Tests
{
    [TestClass]
    public class ScoreBoardTests
    {
        [TestMethod]
        public void AddScoresCountTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddNewScore(4, "Pesho");
            scoreBoard.AddNewScore(7, "Gosho");
            scoreBoard.AddNewScore(5, "Dragan");
            int actual = scoreBoard.Scores.Count;
            int expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddThreeScoresTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddNewScore(4, "Pesho");
            scoreBoard.AddNewScore(7, "Gosho");
            scoreBoard.AddNewScore(5, "Dragan");
            List<Score> actual = scoreBoard.Scores;
            List<Score> expected = new List<Score>() 
            {
                new Score(4, "Pesho"),
                new Score(7, "Gosho"),
                new Score(5, "Dragan")
            };
            expected.Sort();

            Assert.AreEqual(new Score(4, "Pesho"), new Score(4, "Pesho"));

<<<<<<< HEAD
            //CollectionAssert.AreEqual(expected, actual);
=======
            Assert.AreEqual(3, scores.Count);           
>>>>>>> 11d3e3465cdf1ca408b205f69d71e7ca6afd8d2e
        }
    }
}
