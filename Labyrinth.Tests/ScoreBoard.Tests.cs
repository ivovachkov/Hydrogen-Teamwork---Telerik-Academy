using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth.Tests
{
    [TestClass]
    public class ScoreBoardTests
    {
        [TestMethod]
        public void AddNewScoreTest()
        {
            List<Score> scores = new List<Score>() 
            { 
                new Score(4, "Pesho"),
                new Score(7, "Gosho"),
                new Score(5, "Dragan")
            };

            
        }
    }
}
