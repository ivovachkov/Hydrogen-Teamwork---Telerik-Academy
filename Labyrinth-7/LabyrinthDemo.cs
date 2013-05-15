using System;

namespace Labyrinth
{
    public class LabyrinthDemo
    {
        static void Main()
        {
            PlayerPosition startPosition = new PlayerPosition();
            Labyrinth labyrinth = new Labyrinth(startPosition);
                       
            labyrinth.StartGame();
        }
    }
}