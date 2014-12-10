using System;
using System.Collections.Generic;
using Kattis.IO;

public class ExactChange
{
	const int MAX_COST = 10000;

    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        
        int nCases = scanner.NextInt();

        while(nCases-- > 0){
        	int price = scanner.NextInt();
        	int nBills = scanner.NextInt();
        	int[] bills = new int[nBills];
        	int[] dp = new int[MAX_COST + 1];

        	for(int i = 0; i < nBills; i++){
        		bills[i] = scanner.NextInt();
        	}

        	//Array.Sort(bills);

        	for(int i = 1; i <= MAX_COST; i++){
        		dp[i] = Int32.MaxValue;
        	}

        	for(int i = 0; i < nBills; i++){
        		for(int j = MAX_COST; j >= 0; j--){
        			if(dp[j] != Int32.MaxValue){
        				int cost = bills[i] + j;
        				if(cost <= MAX_COST && dp[cost] > dp[j] + 1){
        					dp[j + bills[i]] = dp[j] + 1;
        				}
        			}
        		}
        	}

        	for(int i = price; i <= MAX_COST; i++){
        		if(dp[i] != Int32.MaxValue){
        			string s = i.ToString() + " " + dp[i].ToString() + "\n";
        			writer.Write(s, 0, s.Length);    
        			break;
        		}
        	}
        	
        }



        writer.Flush();
    }
}