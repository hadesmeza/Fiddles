ing System;
using System.Collections.Generic;

public class Program
{
	static Dictionary<int, string> map = new Dictionary<int, string>(){
	{0, "zero"},
	{1, "one"},
	{2, "two"},	
	{3, "three"},
	{4, "four"},
	{5, "five"},
	{6, "six"},
	{7, "seven"},
	{8, "eight"},
	{9, "nine"},
	{10, "ten"},
	{20, "twenty"},
	{30, "thirty"},
	{40, "fourty"},
	{50, "fifty"},
	{60, "sixty"},
	{70, "seventy"},
	{80, "eighty"},
	{90, "ninety"},
	};
	public static void Main()
	{
		Console.WriteLine(GetNumberAsStringIter(1234));		
	}
	
		static string GetNumberAsStringIter(int n){
		var sentence = string.Empty;
		
		var rem = n;
			
		if( rem % 1000 != 0){
			var thousands = rem /1000;
			sentence = thousands > 0 ? (map[thousands] + " thousand " ): "";
			rem %= 1000;
		}
			
	    if( rem % 100 != 0){
			sentence += rem / 100 > 0 ?( map[rem / 100] + " hundred ") : "";
			rem %= 100;
		}
		
		if(rem >= 20 ){
			sentence += GetDoubleDigits(rem);
			rem %=20;
		}else if(rem >= 10){
			sentence += GetTeens(rem);
			rem %= 10;
	    }else if(rem < 10)
			sentence += map[rem];
		
			
		return sentence;
	}
	static string GetNumberAsString(int n){
		
		
		if(n < 10)
			return map[n];
		
		if(n >= 10 && n < 20)
		return GetTeens(n);
		
		if(n >= 20 && n  < 100)
		 return GetDoubleDigits(n);
			
		if(n >= 100 && n < 1000){
			var hundreds = n / 100;
			var rem = n % 100;
			return map[hundreds] + " hundred" + " " + (rem > 0 ? GetNumberAsString(rem): string.Empty);
		}
		
		if(n >= 1000 && n < 1000000){
			var thousands = n / 1000;
			var rem = n % 1000;
			return map[thousands] + " thousand" + " " + (rem > 0 ? GetNumberAsString(rem): string.Empty);
			
		}
		
		
	  return string.Empty;	
	}
	
	static string GetTeens(int n){
		
	var sentence = string.Empty;
		
	 if(n == 10) sentence = map[n];	
		 else if(n == 11) sentence = "eleven";
		 else if(n == 12) sentence = "twelve";
		 else {
			   var ones = n -10;
			   sentence = map[ones]+"teen";
		 }
	
	   return sentence;
	}
	
	static string GetDoubleDigits(int n){
		
		var ones = n % 10;
		var tens = n  - ones ;
		
	    return map[tens] + " " + (ones > 0 ? map[ones] : string.Empty);
	}


	
}
