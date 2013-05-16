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

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddThreeScoresCountTest()
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

            Assert.AreEqual(expected.Count, actual.Count);
        }

        [TestMethod]
        public void ToStringTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddNewScore(4, "Pesho");
            scoreBoard.AddNewScore(7, "Gosho");
            scoreBoard.AddNewScore(5, "Dragan");
            string actual = scoreBoard.ToString();
            string expected = @"
Top 5:

1. Pesho ---> 4 moves
2. Dragan ---> 5 moves
3. Gosho ---> 7 moves


";
            Assert.AreEqual(expected, actual);
        }
    }
}