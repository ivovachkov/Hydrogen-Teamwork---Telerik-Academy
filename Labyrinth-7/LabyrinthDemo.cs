using System;

namespace Labyrinth
{
    public class LabyrinthDemo
    {
        static void Main()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);
            Labyrinth labyrinth = new Labyrinth(startPosition);                       
            labyrinth.StartGame();
        }
    }
}