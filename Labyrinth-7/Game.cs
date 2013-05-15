using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    public abstract class Game
    {
        protected bool isRunning;
        protected bool isFinished;       
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