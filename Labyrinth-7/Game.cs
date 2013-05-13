using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    public abstract class Game
    {
        protected bool isFinished;

        protected bool isRunning;
       
        protected int currentMoves;
        
        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }

        public bool IsGenerationDone
        {
            get { return isFinished; }
            set { isFinished = value; }
        }

        public int CurrentMoves
        {
            get { return currentMoves; }
            protected set { currentMoves = value; }
        }
    }
}