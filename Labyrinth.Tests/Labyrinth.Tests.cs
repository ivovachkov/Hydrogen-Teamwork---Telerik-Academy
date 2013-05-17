using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth.Tests
{
	[TestClass]
	public class LabyrinthTests
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException), "The start position cannot be null")]
		public void Position_NullValue()
		{
			PlayerPosition startPosition = new PlayerPosition();
			startPosition = null;
			Labyrinth labyrinth = new Labyrinth(startPosition);
		}

        [TestMethod]
        public void IsInBorderTest()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);
            Labyrinth labyrinth = new Labyrinth(startPosition);

            var privateObject = new PrivateObject(labyrinth);
            int zero = 0;

            var actual = privateObject.Invoke("IsOnBorder", zero, zero);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }
	}
}