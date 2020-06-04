using System;
using System.Collections.Generic;

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


            //Executes IsRoute pathfinding and prints result
            Boolean completable = AStar.IsRoute(testMaze, 0, 0, 9, 9);
            Console.WriteLine("\nMaze is completable? " + completable);

            //Executes GetRoute and prints the resultant route
            Console.WriteLine("\nMaze Trace:");
            List<Node> route = AStar.GetRoute(testMaze, 0, 0, 9, 9);
            if (route != null)
            {
                foreach (Node node in route)
                {
                    Console.WriteLine(String.Format("({0}, {1})", node.x, node.y));
                }
            }
            else
            {
                Console.WriteLine("No Route Found");
            }
        }
    }
}
