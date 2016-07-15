ing System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		var guess = new char []  { 'G','G', 'R','R'};	
		var source = new char [] { 'R','G', 'B','Y'};
		
		var response = GuessScore(guess, source);
		
		Console.WriteLine("hits " + response.Hits);
		Console.WriteLine("Phits " + response.Phits);
	
	
	}

	static Response GuessScore(char[] guess, char[] source)
	{
		var hits = 0;
		var phits = new HashSet<char>();
		var map = new HashSet<char>();
		
		foreach(var i in source){
			if(map.Contains(i))continue;
			map.Add(i);
		}
			
		
		for (var i = 0; i < guess.Length; i++)
		{
			if (guess[i] == source[i])
			{
				hits++;
				if(phits.Contains(guess[i])) phits.Remove(guess[i]);
				
				if (map.Contains(guess[i]))
					map.Remove(guess[i]);
			}
			else if (map.Contains(guess[i]))
			{
				phits.Add(guess[i]);
				
				map.Remove(guess[i]);
			}
		}

		return new Response{
			Hits = hits,
			Phits = phits.Count
		};
	}

	public class Response
	{
		public int Hits
		{
			get;
			set;
		}

		public int Phits
		{
			get;
			set;
		}
	}
}
