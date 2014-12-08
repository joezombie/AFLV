using System;
using System.Collections.Generic;
using Kattis.IO;
 
public class PlantingTrees
{
	static public int compareTrees(int a, int b){
		if(a == b){
			return 0;
		} else if (a < b){
			return 1;
		} else {
			return -1;
		}
	}
    static public void Main ()
    {
    	Scanner scanner = new Scanner();
    	BufferedStdoutWriter writer = new BufferedStdoutWriter();
    	
    	int nSeedlings = scanner.NextInt();

    	List<int> seedlings = new List<int>();

    	for(int i = 0; i < nSeedlings; i++){
    		seedlings.Add(scanner.NextInt());
    	}

    	seedlings.Sort(compareTrees);

    	int maxTime = 0;
		
    	for(int i = 0; i < seedlings.Count; i++){
    		int sum = seedlings[i] + i + 2;
    		if(sum > maxTime){
    			maxTime = sum;
    		}
    	}

    	//Console.WriteLine(maxTime);

    	string s = maxTime.ToString() + "\n";
        writer.Write(s, 0, s.Length);
	    
	    writer.Flush();
    }
}