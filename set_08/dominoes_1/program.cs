using System;
using System.Collections.Generic;
using Kattis.IO;

public class Program
{
	static public bool[] fallen;
	static public Dictionary<int, List<int>> adj;

	static public void countFallen(int next, bool node){
		if(!fallen[next]){
			fallen[next] = node;
			foreach(int i in adj[next]){
				countFallen(i, true);
			}
		}
	}

    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        
        int nCases = scanner.NextInt();

        while(nCases-- > 0){
        	int nTiles = scanner.NextInt();
        	int nLines = scanner.NextInt();

        	adj = new Dictionary<int, List<int>>();
        	fallen = new bool[nTiles + 1];

	        for(int i = 0; i <= nTiles; i++){
	    		adj.Add(i, new List<int>());
	    	}

        	while(nLines-- > 0){
        		int x = scanner.NextInt();
        		int y = scanner.NextInt();
        		adj[x].Add(y);
        	}

        	for(int i = 1; i <= nTiles; i++){
        		countFallen(i, false);
        	}

        	/*
        	for(int i = 1; i <= nTiles; i++){
        		writer.Write(fallen[i]);
        		writer.Write(" ");
        	}
        	writer.Write("\n");
        	*/

        	int count = 0;
	        for(int i = 1; i <= nTiles; i++){
	        	if(!fallen[i]){
	        		count += 1;
	        	}
	        }
	        writer.WriteLine(count);
        }
        
        writer.Flush();
    }
}