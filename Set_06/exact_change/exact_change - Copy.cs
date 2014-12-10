using System;
using System.Collections.Generic;
using Kattis.IO;

public class ExactChange
{
	static public int nBills;
	static public int[] bills;

	public struct ans{
		public ans(int sum, int count){
			this.sum = sum;
			this.count = count;
		}
		public int sum;
		public int count;

		override public string ToString(){
			return "Sum:" + sum.ToString() 
				 + " Count:" + count.ToString();
		}
	}

	static public ans findSum(int price, ans sum, int i){
	    if(i >= nBills){
	            return sum;
	    }
	    if(sum.sum > price){
	    	return sum;
	    }

	    ans newSum = new ans(sum.sum + bills[i], sum.count + 1);

	    if(newSum.sum < price){
	            sum = findSum(price, sum, i + 1);
	            newSum = findSum(price, newSum, i + 1);
	    }
	    if(sum.sum >= price && newSum.sum >= price){
	    	if(newSum.sum < sum.sum){
	    		return newSum;
	    	} else if (newSum.sum > sum.sum){
	    		return sum;
	    	} else {
	    		if(newSum.count < sum.count){
	    			return newSum;
	    		} else {
	    			return sum;
	    		}
	    	}
	    } else if(sum.sum >= price){
	    	return sum;
	    } else {
	    	return newSum;
	    }
	    
	}

    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        
        int nCases = scanner.NextInt();

        while(nCases-- > 0){
        	int price = scanner.NextInt();
        	nBills = scanner.NextInt();
        	bills = new int[nBills];
        	Dictionary<int, int> available = new Dictionary<int, int>();

        	for(int i = 0; i < nBills; i++){
        		bills[i] = scanner.NextInt();
        	}
        	Array.Sort(bills);

        	ans sum = findSum(price, new ans(0, 0), 0);
	        string s = sum.sum.ToString() + " " + sum.count.ToString() + "\n";
        	writer.Write(s, 0, s.Length);    
        }



        writer.Flush();
    }
}