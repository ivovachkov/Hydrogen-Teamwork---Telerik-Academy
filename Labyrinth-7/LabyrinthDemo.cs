using System;

namespace Labyrinth
{
    // changed class name
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