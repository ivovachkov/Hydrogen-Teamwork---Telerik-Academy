using System;

namespace Labyrinth
{
    public class LabyrinthTest
    {
        static void Main()
        {
            Labyrinth.Pos.X = 3;
            Labyrinth.Pos.Y = 3;
            Game.IsRunning = true;
            string[,] labyrinth = new string[Labyrinth.LabyrinthSize, Labyrinth.LabyrinthSize];

            // The game is running till we stop it with exit command. There we are using Environment.Exit(0);
            // TODO make stoping better
            while (true)
            {
                Console.WriteLine(
                    "Welcome to \"Labyrinth\" game. Please try to escape. " +
                    "Use 'top' to view the top \nscoreboard,'restart' to start " +
                     "a new game and 'exit' to quit the game.\n ");

                Game.IsFinished = false;
                Game.IsWonWithEscape = false;

                while (!Game.IsFinished)
                {
                    Labyrinth.Generate(labyrinth, Labyrinth.Pos.X, Labyrinth.Pos.Y);
                    Labyrinth.SolutionChecker(labyrinth, Labyrinth.Pos.X, Labyrinth.Pos.Y);
                }

                Labyrinth.Print(labyrinth);
                Labyrinth.Test(labyrinth, Game.IsRunning, Labyrinth.Pos.X, Labyrinth.Pos.Y);

                //used for adding score only when game is finished naturally and not by the restart command.
                while (Game.IsWonWithEscape)
                {
                    Labyrinth.AddNewScore(Game.Scores, Game.CurrentMoves);
                }
            }
        }


    }
}
