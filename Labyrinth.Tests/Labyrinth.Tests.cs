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
        public void Test()
        {
            PlayerPosition startPosition = new PlayerPosition(3,3);
            
            Labyrinth labyrinth = new Labyrinth(startPosition);

            var privateObject = new PrivateObject(labyrinth);

            var actual = privateObject.Invoke("test","here","there");

            Assert.AreEqual("herethere", actual);
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
	}
}
