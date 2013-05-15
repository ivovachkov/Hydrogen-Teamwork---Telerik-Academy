
namespace Labyrinth
{
    public abstract class Game
    {
<<<<<<< HEAD
=======
        protected bool isFinished;
        
>>>>>>> f3ed1eaa00561d4a34de5f31485b687206d5aca7
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