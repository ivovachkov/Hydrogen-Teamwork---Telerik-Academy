using System;

namespace Labyrinth
{
    public class Score : IComparable<Score>
    {
        private int moves;
        private string name;

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

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Player's name cannot be null.");
                }

                this.name = value;
            }
        }

        public Score(int moves, string name)
        {
            this.Moves = moves;
            this.Name = name;
        }

        // implemented compareto for easier sorting
        public int CompareTo(Score other)
        {
            return this.Moves.CompareTo(other.Moves);
        }
    }
}