using System;
using System.Collections.Generic;
using Kattis.IO;

public class Program
{
	const int MAX_TILES = 10000;

	static public bool[] fallen;
	static public Dictionary<int, List<int>> adj;

	static public void countFallen(int next){
		if(!fallen[next]){
			fallen[next] = true;
			foreach(int i in adj[next]){
				countFallen(i);
			}
		}
	}

    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        
        int nCases = scanner.NextInt();

        while(nCases-- > 0){
        	int n = scanner.NextInt();
        	int m = scanner.NextInt();
        	int l = scanner.NextInt();

        	adj = new Dictionary<int, List<int>>();
        	fallen = new bool[n + 1];

        	for(int i = 0; i <= n; i++){
        		adj.Add(i, new List<int>());
        	}

        	for(int i = 0; i < m; i++){
        		adj[scanner.NextInt()].Add(scanner.NextInt());
        	}

        	for(int i = 0; i < l; i++){
        		int z = scanner.NextInt();
        		//adj[z] = null;
        		countFallen(z);
        	}

    		int count = 0;
    		for(int i = 1; i < n + 1; i++){
    			//writer.Write(fallen[i]);
    			//writer.Write(" ");
    			if(fallen[i]) { count += 1; }
    		}
    		//writer.WriteLine();

        	writer.WriteLine(count);
        }

        writer.Flush();
    }
}