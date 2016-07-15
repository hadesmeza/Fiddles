ing System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main()
	{
		var  x = new Node{ Value = 1};
		x.Left = new Node{ Value = 2};
		x.Right = new Node{ Value = 3};
		
		x.Left.Left = new Node{ Value = 4};
		x.Left.Right = new Node{ Value = 5};
		
		x.Right.Left = new Node{ Value = 6};
		x.Right.Right = new Node{ Value = 7};
		
		x.Right.Right.Right = new Node{ Value = 8};
		
		Console.WriteLine( GetLevelsCountBfs(x));
		var lists = GetLevelsAsLists(x);
		Console.WriteLine("-----");
		foreach(var l in lists ){
		  Console.WriteLine(string.Join(",", l.Select(i => i.Value)));
		}
		
	}
	
	/*
	
	get items per level
	increment levelcnt
	add children to queue of the current level
	
	
	*/
	static int GetLevelsCountBfs(Node root){
		var levels = 0;
		var q = new Queue<Node>();
		q.Enqueue(root);
		
		while(q.Count > 0 ){
		 var itemsPerLevel = q.Count; 
		 levels++;
			while(itemsPerLevel > 0){
		        var current = q.Dequeue();
				if(current.Left != null) q.Enqueue(current.Left);
				if(current.Right != null) q.Enqueue(current.Right);
			
				itemsPerLevel--;
			
			}
		
		}
	
	return levels;
	}
		static List<List<Node>> GetLevelsAsLists(Node root){
		var levels = 0;
		var q = new Queue<Node>();
			
		q.Enqueue(root);
			
		var l = new List<List<Node>>();
		l.Add( new List<Node>(){ root });	
		
		while(q.Count > 0 ){
		 var itemsPerLevel = q.Count; 
		 levels++;
		 var newList = new List<Node>();
			while(itemsPerLevel > 0){
		        var current = q.Dequeue();
				
				if(current.Left != null){
					newList.Add(current.Left);
					q.Enqueue(current.Left);
				}
				if(current.Right != null){
					
					newList.Add(current.Right);
					q.Enqueue(current.Right);
				}
			
				itemsPerLevel--;
			
			}
			if(newList.Count > 0 ) l.Add(newList);
		
		}
	
	return l;
	}
	
	
	public class Node{
	
		public int Value {get;set;}
		public Node Left {get;set;}
		public Node Right {get;set;}
	
	}

}
