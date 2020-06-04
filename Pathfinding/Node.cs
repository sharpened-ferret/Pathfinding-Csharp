using System;

public class Node
{
	public Node parent;
	public int x;
	public int y;

	public int g;
	public int h;
	public int f;


	public Node(Node parent, int x, int y)
	{
		this.parent = parent;
		this.x = x;
		this.y = y;
	}

	public override bool Equals(object obj)
	{
		//Check if null and whether types match
		if ((obj == null) || !this.GetType().Equals(obj.GetType()))
		{
			return false;
		}
		else
		{
			Node n = (Node)obj;
			return (this.x == n.x && this.y == n.y);
		}
	}

	public override string ToString()
	{
		if (this.parent != null)
		{
			return String.Format("NodePos=({0}, {1})  g={2} h={3} f={4}  ParentPos=({5}, {6})", this.x, this.y, this.g, this.h, this.f, parent.x, parent.y);
		}
		return String.Format("NodePos=({0}, {1})  g={2} h={3} f={4}  Parent=null", this.x, this.y, this.g, this.h, this.f);
	}

	public override int GetHashCode()
	{
		unchecked //Ignores overflow
		{
			int hash = 71;
			hash = hash * 47 + this.x;
			hash = hash * 47 + this.y;
			return hash;
		}
	}
}
