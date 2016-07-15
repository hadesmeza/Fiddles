ing System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		/*
		    1
		2	    3
	  4   5   6   7
	             10
		
		*/
		var t = new Node<int>(1);
		t.Left = new Node<int>(2);
		t.Right = new Node<int>(3);
		t.Left.Left = new Node<int>(4);
		t.Left.Right = new Node<int>(5);
		t.Right.Left = new Node<int>(6);
		t.Right.Right = new Node<int>(7);
		t.Right.Right.Left = new Node<int>(10);
		
		Console.WriteLine(Serialize(t));
		PrintTree(Deserialize(Serialize(t)));
	}

	static void PrintTree(Node<int> node)
	{
		var q = new Queue<Node<int>>();
		q.Enqueue(node);
		while (q.Count > 0)
		{
			var current = q.Dequeue();
			Console.WriteLine(current.Value);
			if (current.Left != null)
				q.Enqueue(current.Left);
			if (current.Right != null)
				q.Enqueue(current.Right);
		}
	}

	//1|l:2:1|3:1|l:4:2|5:2|l:6:3|7:3|l:10:7
	static string Serialize<T>(Node<T> node)
	{
		var nodes = new List<string>();
		var q = new Queue<Node<T>>();
		q.Enqueue(node);
		nodes.Add(string.Format("{0}", node.Value));
		while (q.Count > 0)
		{
			var parent = q.Dequeue();
			if (parent.Left != null)
			{
				nodes.Add(string.Format("l:{0}:{1}", parent.Left.Value, parent.Value));
				q.Enqueue(parent.Left);
			}

			if (parent.Right != null)
			{
				nodes.Add(string.Format("{0}:{1}", parent.Right.Value, parent.Value));
				q.Enqueue(parent.Right);
			}
		}

		return string.Join("|", nodes);
	}

	static Node<int> Deserialize(string t)
	{
		var nodes = t.Split('|');
		var root = new Node<int>(int.Parse(nodes[0]));
		var map = new Dictionary<int, Node<int>>(nodes.Length);
		
		map.Add(root.Value, root);
		
		for (var i = 1; i < nodes.Length; i++)
		{
			var nodeFragment = GetNodeFragment(nodes[i]);
			
			var node = new Node<int>(nodeFragment.nodeValue);
			
			map.Add(node.Value, node);
			
			var parent = map[nodeFragment.nodeParent];
			
			if (nodeFragment.position == "l")
				parent.Left = node;
			else
				parent.Right = node;
		}

		return root;
	}

	public struct NodeFragment
	{
		public string position
		{
			get;
			set;
		}

		public int nodeValue
		{
			get;
			set;
		}

		public int nodeParent
		{
			get;
			set;
		}
	}

	static NodeFragment GetNodeFragment(string s)
	{
		var parts = s.Split(':');
		var isRightPositioned = parts.Length == 2;
		return new NodeFragment()
		{	
		    position   = isRightPositioned ? "r" : "l",
			nodeValue  = int.Parse(parts[isRightPositioned ? 0 : 1]),
			nodeParent = int.Parse(parts[isRightPositioned ? 1 : 2])
		};
	}

	public class Node<T>
	{
		public T Value
		{
			get;
			set;
		}

		public Node<T> Left
		{
			get;
			set;
		}

		public Node<T> Right
		{
			get;
			set;
		}

		public Node()
		{
		}

		public Node(T val)
		{
			Value = val;
		}
	}
}
