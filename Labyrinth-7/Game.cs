using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    public class Game
    {
        protected static bool isFinished;

        protected static bool isRunning;

        protected static bool isWonWithEscape;

        protected static Position pos = new Position();

       // public static int positionX;

       // public static int positionY;

        private static int currentMoves;

        public static List<Table> Scores = new List<Table>(4);

        public static Position Pos
        {
            get
            {
                return pos;
            }
            set
            {
                pos = value;
            }
        }

        public static bool IsWonWithEscape
        {
            get
            {
                return isWonWithEscape;
            }
            set
            {
                isWonWithEscape = value;
            }
        }

        public static bool IsRunning
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

        public static bool IsFinished
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

        public static Position Position
        {
            get
            {
                return pos;
            }
            set
            {
                pos = value;
            }
        }

        public static int CurrentMoves
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