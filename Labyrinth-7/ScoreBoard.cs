using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class ScoreBoard
    {
        private const int Capacity = 5;
        private List<Score> scores = new List<Score>(Capacity);

        public void AddNewScore(int moves, string name)
        {
            if (scores.Count < Capacity)
            {
                scores.Add(new Score(moves, name));
            }
            else if (scores.Count == Capacity)
            {
                if (scores[4].Moves > moves)
                {
                    scores.Remove(scores[4]);
                    scores.Add(new Score(moves, name));
                }
            }
            scores.Sort();
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine();

            if (scores.Count == 0)
            {
                result.AppendLine("The scoreboard is empty!");
            }
            else
            {
                result.AppendLine("Top 5: \n");
                for (int i = 0; i < scores.Count; i++)
                {
                    int rankPosition = i + 1;
                    result.AppendFormat(rankPosition + ". {1} ---> {0} moves", 
                        scores[i].Moves, scores[i].Name);
                    result.AppendLine();
                }

                result.AppendLine("\n");
            }

            return result.ToString();
        }
    }
}