using System;
using System.Collections.Generic;

namespace Labyrinth
{
    public class Labyrinth : Game
    {
        public const int LabyrinthSize = 7;

        static void Main()
        {
            positionX = 3;
            positionY = 3;
            Game.isRunning = true;
            
            string[,] labyrinth = new string[LabyrinthSize, LabyrinthSize];


            // The game is running till we stop it with exit command. There we are using Environment.Exit(0);
            // TODO make stoping better
            while (true)
            {
                Console.WriteLine(
                    "Welcome to \"Labyrinth\" game. Please try to escape. " + 
                    "Use 'top' to view the top \nscoreboard,'restart' to start "+
                     "a new game and 'exit' to quit the game.\n ");

                Game.isFinished = false;
                Game.isWonWithEscape = false;

                while (!Game.isFinished)
                {
                    LabyrinthGenerator(labyrinth, positionX, positionY);
                    SolutionChecker(labyrinth, positionX, positionY);
                }

                PrintLabyrinth(labyrinth);
                Test(labyrinth, Game.isRunning, positionX, positionY);
                
                //used for adding score only when game is finished naturally and not by the restart command.
                while (Game.isWonWithEscape) 
                {
                    AddNewScore(Scores, Game.CurrentMoves);
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

            isWonWithEscape = false;
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

        static void Test(string[,] labyrinth, bool flagTemp, int moveCount, int y)
        {
            Game.CurrentMoves = 0;

            while (flagTemp)
            {
                Console.Write("\nEnter your move (L=left, R=right, D=down, U=up): ");
                string moveDirrection = string.Empty;
                moveDirrection = Console.ReadLine();

                switch (moveDirrection)
                {
                    case "d":

                        if (labyrinth[moveCount + 1, y] == "-")
                        {
                            labyrinth[moveCount, y] = "-";
                            labyrinth[moveCount + 1, y] = "*";
                            moveCount++;
                            Game.CurrentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (moveCount == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n",
                                Game.CurrentMoves);

                            flagTemp = false;
                            isWonWithEscape = true;
                        }

                        PrintLabyrinth(labyrinth);
                        break;
                    case "D":
                        if (labyrinth[moveCount + 1, y] == "-")
                        {
                            labyrinth[moveCount, y] = "-";
                            labyrinth[moveCount + 1, y] = "*";
                            moveCount++;
                            Game.CurrentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (moveCount == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n",
                                Game.CurrentMoves);

                            flagTemp = false;
                            isWonWithEscape = true;
                        }

                        PrintLabyrinth(labyrinth);

                        break;
                    case "u":
                        if (labyrinth[moveCount - 1, y] == "-")
                        {
                            labyrinth[moveCount, y] = "-";
                            labyrinth[moveCount - 1, y] = "*";
                            moveCount--;
                            Game.CurrentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (moveCount == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", Game.CurrentMoves);
                            flagTemp = false;
                            isWonWithEscape = true;
                        }

                        PrintLabyrinth(labyrinth);
                        break;
                    case "U":
                        if (labyrinth[moveCount - 1, y] == "-")
                        {
                            labyrinth[moveCount, y] = "-";
                            labyrinth[moveCount - 1, y] = "*";
                            moveCount--;
                            Game.CurrentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (moveCount == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", Game.CurrentMoves);
                            flagTemp = false;
                            isWonWithEscape = true;
                        }

                        PrintLabyrinth(labyrinth);

                        break;
                    case "r":

                        if (labyrinth[moveCount, y + 1] == "-")
                        {
                            labyrinth[moveCount, y] = "-";
                            labyrinth[moveCount, y + 1] = "*";
                            y++;
                            Game.CurrentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (y == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n",
                                Game.CurrentMoves);

                            flagTemp = false;
                            isWonWithEscape = true;
                        }

                        PrintLabyrinth(labyrinth);

                        break;
                    case "R":

                        if (labyrinth[moveCount, y + 1] == "-")
                        {
                            labyrinth[moveCount, y] = "-";
                            labyrinth[moveCount, y + 1] = "*";
                            y++;
                            Game.CurrentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (y == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n",
                                Game.CurrentMoves);

                            flagTemp = false;
                            isWonWithEscape = true;
                        }

                        PrintLabyrinth(labyrinth);
                        break;
                    case "l":

                        if (labyrinth[moveCount, y - 1] == "-")
                        {
                            labyrinth[moveCount, y] = "-";
                            labyrinth[moveCount, y - 1] = "*";
                            y--;
                            Game.CurrentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (y == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", 
                                Game.CurrentMoves);

                            flagTemp = false;
                            isWonWithEscape = true;
                        }

                        PrintLabyrinth(labyrinth);

                        break;
                    case "L":

                        if (labyrinth[moveCount, y - 1] == "-")
                        {
                            labyrinth[moveCount, y] = "-";
                            labyrinth[moveCount, y - 1] = "*";
                            y--;
                            Game.CurrentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (y == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", Game.CurrentMoves);
                            flagTemp = false;
                            isWonWithEscape = true;
                        }

                        PrintLabyrinth(labyrinth);

                        break;
                    case "top":
                        UpdateScoreSheet(Scores);
                        Console.WriteLine("\n");
                        PrintLabyrinth(labyrinth);
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