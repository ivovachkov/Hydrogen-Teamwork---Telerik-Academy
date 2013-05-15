namespace Labyrinth
{
    public class Position
    {
        private int x;
        private int y;

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Position()
        { }

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }
    }
}
