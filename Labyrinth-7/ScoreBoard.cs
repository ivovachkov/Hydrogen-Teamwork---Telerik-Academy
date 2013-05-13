using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public static class ScoreBoard
    {
        private const int Capacity = 5;
        private static List<Score> scores = new List<Score>(Capacity);

        public static void AddNewScore(int moves, string name)
        {
            if (scores.Count != 0)
            {
                scores.Sort();
            }

            if (scores.Count < Capacity)
            {
                scores.Add(new Score(moves, name));
                Display();
            }
            else if (scores.Count == Capacity)
            {
                if (scores[4].Moves > moves)
                {
                    scores.Remove(scores[4]);
                    scores.Add(new Score(moves, name));
                    Display();
                }
            }            
        }

        public static void Display()
        {
            Console.WriteLine("\n");
            if (scores.Count == 0)
            {
				Console.WriteLine("The scoreboard is empty!");
            }
            else
            {
                scores.Sort();
                Console.WriteLine("Top 5: \n");
                for (int i = 0; i < scores.Count; i++)
                {
                    int rankPosition = i + 1;
                    Console.WriteLine(
                        String.Format(rankPosition + ". {1} ---> {0} moves", scores[i].Moves, scores[i].Name));
                }

                Console.WriteLine("\n");
            }
        }
    }
}
