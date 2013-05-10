using System;

namespace Labyrinth
{
    public class LabyrinthTest
    {
        static void Main()
        {
            Game.Position.X = 3;
            Game.Position.Y = 3;
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
                    Labyrinth.LabyrinthGenerator(labyrinth, Game.Position.X, Game.Position.Y);
                    Labyrinth.SolutionChecker(labyrinth, Game.Position.X, Game.Position.Y);
                }

                Labyrinth.PrintLabyrinth(labyrinth);
                Labyrinth.Test(labyrinth, Game.IsRunning, Game.Position.X, Game.Position.Y);

                //used for adding score only when game is finished naturally and not by the restart command.
                while (Game.IsWonWithEscape)
                {
                    Labyrinth.AddNewScore(Game.Scores, Game.CurrentMoves);
                }
            }
        }


    }
}
