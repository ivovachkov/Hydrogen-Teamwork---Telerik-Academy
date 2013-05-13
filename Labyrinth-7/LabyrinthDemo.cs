using System;

namespace Labyrinth
{
    // changed class name
    public class LabyrinthDemo
    {
        static void Main()
        {
            Position startPosition = new Position(3, 3);
            Labyrinth labyrinth = new Labyrinth(startPosition);
            string[,] labyrinthBoard = new string[Labyrinth.LabyrinthSize, Labyrinth.LabyrinthSize];
            labyrinth.IsRunning = true;
            
            // The game is running till we stop it with exit command. There we are using Environment.Exit(0);
            // TODO make stoping better
            while (true)
            {
                Console.WriteLine("Welcome to \"Labyrinth\" game. Please try to escape. " +
                                  "Use 'top' to view the top \nscoreboard,'restart' to start " +
                                  "a new game and 'exit' to quit the game.\n ");

                labyrinth.IsGenerationDone = false;
                labyrinth.IsWonWithEscape = false;
                
                
                while (!labyrinth.IsGenerationDone)
                {
                    labyrinth.Generate(labyrinthBoard, labyrinth.Pos.X, labyrinth.Pos.Y);
                    labyrinth.SolutionChecker(labyrinthBoard, labyrinth.Pos.X, labyrinth.Pos.Y);
                }

                Console.WriteLine(labyrinth.Print(labyrinthBoard));
                labyrinth.Run(labyrinthBoard, labyrinth.IsRunning, labyrinth.Pos.X, labyrinth.Pos.Y);

                //used for adding score only when game is finished naturally and not by the restart command.
                if (labyrinth.IsWonWithEscape)
                {
                    labyrinth.AddNewScore(labyrinth.Scores, labyrinth.CurrentMoves);
                }
            }
        }
    }
}