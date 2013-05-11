using System;

namespace Labyrinth
{
    public class LabyrinthTest
    {
        static void Main()
        {
            Position startPosition = new Position(3, 3);
            Labyrinth labyrinth = new Labyrinth(startPosition);

            labyrinth.IsRunning = true;
            string[,] labyrinthBoard = new string[Labyrinth.LabyrinthSize, Labyrinth.LabyrinthSize];

            // The game is running till we stop it with exit command. There we are using Environment.Exit(0);
            // TODO make stoping better
            while (true)
            {
                Console.WriteLine(
                    "Welcome to \"Labyrinth\" game. Please try to escape. " +
                    "Use 'top' to view the top \nscoreboard,'restart' to start " +
                     "a new game and 'exit' to quit the game.\n ");

                labyrinth.IsFinished = false;
                labyrinth.IsWonWithEscape = false;

                // removed while cicle
                while (!labyrinth.IsFinished)
                {
                    labyrinth.Generate(labyrinthBoard, labyrinth.Pos.X, labyrinth.Pos.Y);
                    labyrinth.SolutionChecker(labyrinthBoard, labyrinth.Pos.X, labyrinth.Pos.Y);
                }

                labyrinth.Print(labyrinthBoard);
                labyrinth.Test(labyrinthBoard, labyrinth.IsRunning,labyrinth.Pos.X, labyrinth.Pos.Y);

                //used for adding score only when game is finished naturally and not by the restart command.
                while (labyrinth.IsWonWithEscape)
                {
                    labyrinth.AddNewScore(labyrinth.Scores, labyrinth.CurrentMoves);
                }
            }
        }


    }
}
