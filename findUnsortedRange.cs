ing System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main()
	{
		var guess = new int []  { 1,2,4,7,10,11,7,12,6,7,16,18,19};
		
		var res = GetRange(guess);
		Console.WriteLine("st " +res[0]);
		
		Console.WriteLine("end " + res[1]);
	
	}
	
	static List<int> GetRange(int[] a){
	
	var prev = a[0];
	var lows = new List<int>();
	var max = prev;
		
		for(var i = 1; i < a.Length; i++){
		
		var current = a[i];
			
			if(current > prev)
				if(current > max)max = current;
			
			if(current < max) 
				lows.Add(i);
			
			prev = current;
		}
		
	    var last = lows.Last();
		var first = 0;
		
		for(var i =0; i < last; i++)
		{
		   if(a[i] < a[last]) continue;
			
			first = i;
			break;
		}
	
		return new List<int> {first, last};
	}


	
}
