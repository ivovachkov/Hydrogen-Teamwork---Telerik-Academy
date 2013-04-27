namespace Labyrinth
{
    public class Table
    {
        private int availableMoves;

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
                return this.availableMoves;
            }
            set
            {
                this.availableMoves = value;
            }
        }

        public Table(int moves, string name)
        {
            this.availableMoves = moves;
            this.name = name;
        }
    }
}