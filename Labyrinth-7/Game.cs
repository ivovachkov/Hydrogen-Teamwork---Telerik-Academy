namespace Labyrinth
{
    public abstract class Game
    {
        protected bool isRunning;     
        protected int currentMoves;
        
        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }

            set
            {
                isRunning = value;
            }
        }

        public int CurrentMoves
        {
            get
            {
                return this.currentMoves;
            }

            protected set
            {
                this.currentMoves = value;
            }
        }
    }
}