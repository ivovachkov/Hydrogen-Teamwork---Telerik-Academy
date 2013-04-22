namespace Labyrinth
{
    public class Table
    {
        private int moves;
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Moves
        {
            get
            {
                return this.moves;
            }
            set
            {
                this.moves = value;
            }
        }

        public Table(int moves, string name)
        {
            this.moves = moves;
            this.name = name;
        }
    }
}