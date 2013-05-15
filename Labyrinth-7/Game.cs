
namespace Labyrinth
{
    public abstract class Game
    {
<<<<<<< HEAD
=======
        protected bool isFinished;
        
>>>>>>> 11d3e3465cdf1ca408b205f69d71e7ca6afd8d2e
        protected bool isRunning;
        protected bool isFinished;       
        protected int currentMoves;
        
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                isRunning = value;
            }
        }

        public bool IsGenerationDone
        {
            get
            {
                return isFinished;
            }
            set
            {
                isFinished = value;
            }
        }

        public int CurrentMoves
        {
            get
            {
                return currentMoves;
            }
            protected set
            {
                currentMoves = value;
            }
        }
    }
}