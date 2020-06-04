using System;

namespace Pathfinding
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Pathfinding Demo\n");

            //Example grid '0' is passable '1' is not
            int[][] testMaze = {new int[] {0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            //Prints example maze to screen
            foreach (int[] row in testMaze)
            {
                string line = "";
                foreach (int pos in row)
                {
                    line += pos;
                }
                Console.WriteLine(line);
            }

            //Executes pathfinding and prints result
            Boolean completable = AStar.IsRoute(testMaze, 0, 0, 9, 9);
            Console.WriteLine("\n Maze is completable? " + completable);
        }
    }
}
