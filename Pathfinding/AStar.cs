using System;
using System.Collections.Generic;

//This class implements AStar pathfinding for a 2d coordinate grid, where '0' indicates a passable position on the grid
public class AStar
{
    //Returns true if there is a route, through the given maze, between the start and end positions, and false otherwise
    public static Boolean IsRoute(int[][] maze, int startX, int startY, int endX, int endY)
    {
        //Initialises the size of the coordinate space
        int mazeHeight = maze.Length;
        int mazeWidth = maze[0].Length;

        Node startNode = new Node(null, startX, startY);
        startNode.g = startNode.h = startNode.f = 0;

        Node endNode = new Node(null, endX, endY);
        endNode.g = endNode.h = endNode.f = 0;

        List<Node> openList = new List<Node>();
        List<Node> closedList = new List<Node>();

        openList.Add(startNode);

        while(openList.Count > 0)
        {
            //Gets current node
            Node currentNode = openList[0];

            foreach (Node node in openList)
            {
                if (node.f < currentNode.f)
                {
                    currentNode = node;
                }
            }
            closedList.Add(currentNode);
            openList.Remove(currentNode);

            //If endNode is reached, returns true
            if (currentNode.Equals(endNode))
            {
                return true;
            }

            //Generates Children
            List<Node> children = new List<Node>();
            //ensures children are not generated outside of the coordinate space
            if ((currentNode.x + 1) < mazeWidth)
            {
                children.Add(new Node(currentNode, currentNode.x + 1, currentNode.y));
            }
            if ((currentNode.x - 1) >= 0)
            {
                children.Add(new Node(currentNode, currentNode.x - 1, currentNode.y));
            }
            if ((currentNode.y + 1) < mazeHeight)
            {
                children.Add(new Node(currentNode, currentNode.x, currentNode.y + 1));
            }
            if ((currentNode.y - 1) >= 0)
            {
                children.Add(new Node(currentNode, currentNode.x, currentNode.y - 1));
            }

            foreach (Node child in children)
            {
                Boolean skip = false;
                foreach (Node closedNode in closedList)
                {
                    if (child.Equals(closedNode))
                    {
                        skip = true;
                    }
                }

                //Skips adding the node if it is impassable 
                if (maze[child.y][child.x] != 0)
                {
                    skip = true;
                }

                if (!skip)
                {
                    //Calculates distance travelled and heuristic distance to end point
                    child.g = currentNode.g + 1;
                    child.h = (int)(Math.Pow((child.x - endX), 2) + Math.Pow((child.y - endY), 2));
                    child.f = child.g + child.h;

                    if (openList.Contains(child))
                    {
                        Node openNode = openList[openList.IndexOf(child)];
                        if (child.g < openNode.g)
                        {
                            openList.Remove(openNode);
                            openList.Add(child);
                        }
                    }

                    else
                    {
                        openList.Add(child);
                    }
                }
            }
        }

        //Default return if no route is found
        return false;
    }




    public static List<Node> GetRoute(int[][] maze, int startX, int startY, int endX, int endY)
    {
        //Initialises the size of the coordinate space
        int mazeHeight = maze.Length;
        int mazeWidth = maze[0].Length;

        Node startNode = new Node(null, startX, startY);
        startNode.g = startNode.h = startNode.f = 0;

        Node endNode = new Node(null, endX, endY);
        endNode.g = endNode.h = endNode.f = 0;

        List<Node> openList = new List<Node>();
        List<Node> closedList = new List<Node>();

        openList.Add(startNode);

        while (openList.Count > 0)
        {
            //Gets current node
            Node currentNode = openList[0];

            foreach (Node node in openList)
            {
                if (node.f < currentNode.f)
                {
                    currentNode = node;
                }
            }
            closedList.Add(currentNode);
            openList.Remove(currentNode);

            //If endNode is reached, traces back the route and returns it as a list of nodes
            if (currentNode.Equals(endNode))
            {
                List<Node> returnList = new List<Node>();
                while (currentNode != null)
                {
                    returnList.Add(currentNode);
                    currentNode = currentNode.parent;
                }
                returnList.Reverse();
                return returnList;
            }

            //Generates Children
            List<Node> children = new List<Node>();
            //ensures children are not generated outside of the coordinate space
            if ((currentNode.x + 1) < mazeWidth)
            {
                children.Add(new Node(currentNode, currentNode.x + 1, currentNode.y));
            }
            if ((currentNode.x - 1) >= 0)
            {
                children.Add(new Node(currentNode, currentNode.x - 1, currentNode.y));
            }
            if ((currentNode.y + 1) < mazeHeight)
            {
                children.Add(new Node(currentNode, currentNode.x, currentNode.y + 1));
            }
            if ((currentNode.y - 1) >= 0)
            {
                children.Add(new Node(currentNode, currentNode.x, currentNode.y - 1));
            }

            foreach (Node child in children)
            {
                Boolean skip = false;
                foreach (Node closedNode in closedList)
                {
                    if (child.Equals(closedNode))
                    {
                        skip = true;
                    }
                }

                //Skips adding the node if it is impassable 
                if (maze[child.y][child.x] != 0)
                {
                    skip = true;
                }

                if (!skip)
                {
                    //Calculates distance travelled and heuristic distance to end point
                    child.g = currentNode.g + 1;
                    child.h = (int)(Math.Pow((child.x - endX), 2) + Math.Pow((child.y - endY), 2));
                    child.f = child.g + child.h;
                    child.parent = currentNode;

                    if (openList.Contains(child))
                    {
                        Node openNode = openList[openList.IndexOf(child)];
                        if (child.g < openNode.g)
                        {
                            openList.Remove(openNode);
                            openList.Add(child);
                        }
                    }

                    else
                    {
                        openList.Add(child);
                    }
                }
            }
        }

        //Default returns null if no route is found
        return null;
    }
}