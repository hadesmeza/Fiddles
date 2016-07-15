ing System;

public class Program
{
	public static void Main()
	{
		var arr = new [] { 15,16,19,20,25,1,3,4,5,7,10,14};
		Console.WriteLine(FindIndex(0, arr.Length - 1, arr,  5));
		
	}
	
	
	static int FindIndex(int st, int end, int [] arr, int val){
		
		Console.WriteLine(string.Format("st:{0} end: {1}", st, end));
		
		var mid = (st + end)/2;
		
		if(arr[mid] == val ) return mid;
		
		
		if(mid - 1 >= st && arr[mid - 1] == val )return mid - 1;
		
		if(mid + 1 <= end && arr[mid + 1] == val )return mid  + 1;
		
		if(arr[st] < val){
			while(arr[mid] < val)mid--;
			return FindIndex(st, mid, arr, val);
		}
		
		
		if(val < arr[end] ){
			
			while(arr[mid] > val)mid++;
			return FindIndex(mid , end, arr, val);
		}
	    
		
	return -1;
	}

}
