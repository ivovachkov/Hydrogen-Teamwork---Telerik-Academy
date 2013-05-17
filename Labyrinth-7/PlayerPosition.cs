﻿namespace Labyrinth
{
    public class PlayerPosition
    {
        private int x;
        private int y;

        public PlayerPosition()
        { }

        public PlayerPosition(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }
    }
}
