﻿using System;
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
        
        public void Position_NullValue()
        {
            PlayerPosition startPosition = new PlayerPosition();
            startPosition = null;
            Labyrinth labyrinth = new Labyrinth(startPosition);
        }
	}
}
