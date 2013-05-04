using System;
using System.Collections.Generic;

namespace Labyrinth
{
    class Labyrinth : Game
    {
        public const int LabyrinthSize = 7;

        static void Main(string[] args)
        {
            positionX = 3;
            positionY = 3;
            flag2 = true;
            flag3 = true;
            string[,] labyrinth = new string[LabyrinthSize, LabyrinthSize];

            while (flag3)
            {
                Console.WriteLine(
                    "Welcome to \"Labyrinth\" game. Please try to escape. " + 
                    "Use 'top' to view the top \nscoreboard,'restart' to start a new game and 'exit' to quit the game.\n ");

                flag = false;
                flag4 = false;

                while (!flag)
                {
                    LabyrinthGenerator(labyrinth, positionX, positionY);
                    SolutionChecker(labyrinth, positionX, positionY);
                }
                DisplayLabyrinth(labyrinth);
                Test(labyrinth, flag2, positionX, positionY);
                while (flag4) //used for adding score only when game is finished naturally and not by the restart command.
                {
                    AddNewScore(Scores, currentMoves);
                }
            }
        }

        static void AddNewScore(List<Table> scores, int moves)
        {
            if (scores.Count != 0)
            {
                scores.Sort(delegate(Table firstScore, Table secondScore)
                {
                    return firstScore.Moves.CompareTo(secondScore.Moves);
                });
            }

            if (scores.Count == 5)
            {
                if (scores[4].Moves > moves)
                {
                    scores.Remove(scores[4]);
                    Console.WriteLine("Please enter your nickname");
                    string name = Console.ReadLine();
                    scores.Add(new Table(moves, name));
                    UpdateScoreSheet(scores);
                }
            }
            if (scores.Count < 5)
            {
                Console.WriteLine("Please enter your nickname");
                string name = Console.ReadLine();
                scores.Add(new Table(moves, name));
                UpdateScoreSheet(scores);
            }

            flag4 = false;
        }

        static void UpdateScoreSheet(List<Table> scores)
        {
            Console.WriteLine("\n");
            if (scores.Count == 0)
            {
                Console.WriteLine("The scoreboard is empty! ");
            }
            else
            {
                int rankPosition = 1;
                scores.Sort(
                    delegate(Table firstScore, Table secondScore)
                    {
                        return firstScore.Moves.CompareTo(secondScore.Moves);
                    }
                );
                Console.WriteLine("Top 5: \n");

                scores.ForEach(
                    delegate(Table score)
                    {
                        Console.WriteLine(String.Format(rankPosition + ". {1} ---> {0} moves", score.Moves, score.Name));
                        rankPosition++;
                    }
                );
                Console.WriteLine("\n");
            }
        }

        static void Test(string[,] labyrinth, bool flagTemp, int x, int y)
        {
            currentMoves = 0;

            while (flagTemp)
            {
                Console.Write("\nEnter your move (L=left, R=right, D=down, U=up): ");
                string moveDirrection = string.Empty;
                moveDirrection = Console.ReadLine();

                switch (moveDirrection)
                {
                    case "d":

                        if (labyrinth[x + 1, y] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x + 1, y] = "*";
                            x++;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (x == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flagTemp = false;

                            flag4 = true;
                        }

                        DisplayLabyrinth(labyrinth);
                        break;
                    case "D":
                        if (labyrinth[x + 1, y] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x + 1, y] = "*";
                            x++;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (x == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flagTemp = false;
                            flag4 = true;
                        }

                        DisplayLabyrinth(labyrinth);

                        break;
                    case "u":
                        if (labyrinth[x - 1, y] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x - 1, y] = "*";
                            x--;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (x == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flagTemp = false;
                            flag4 = true;
                        }

                        DisplayLabyrinth(labyrinth);

                        break;
                    case "U":
                        if (labyrinth[x - 1, y] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x - 1, y] = "*";
                            x--;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (x == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flagTemp = false;
                            flag4 = true;
                        }

                        DisplayLabyrinth(labyrinth);

                        break;
                    case "r":

                        if (labyrinth[x, y + 1] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x, y + 1] = "*";
                            y++;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (y == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flagTemp = false;
                            flag4 = true;
                        }

                        DisplayLabyrinth(labyrinth);

                        break;
                    case "R":

                        if (labyrinth[x, y + 1] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x, y + 1] = "*";
                            y++;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (y == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flagTemp = false;
                            flag4 = true;
                        }

                        DisplayLabyrinth(labyrinth);

                        break;
                    case "l":

                        if (labyrinth[x, y - 1] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x, y - 1] = "*";
                            y--;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (y == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flagTemp = false;
                            flag4 = true;
                        }

                        DisplayLabyrinth(labyrinth);

                        break;
                    case "L":

                        if (labyrinth[x, y - 1] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x, y - 1] = "*";
                            y--;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (y == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flagTemp = false;
                            flag4 = true;
                        }

                        DisplayLabyrinth(labyrinth);

                        break;
                    case "top":
                        UpdateScoreSheet(Scores);
                        Console.WriteLine("\n");
                        DisplayLabyrinth(labyrinth);
                        break;
                    case "restart":
                        flagTemp = false;
                        break;
                    case "exit":
                        Console.WriteLine("Good bye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }
        }
    }
}