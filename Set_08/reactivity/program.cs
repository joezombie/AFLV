using System;
using System.Collections.Generic;
using Kattis.IO;

public class Program
{
	//const int MAX_NODES = 500000;
	//static List<int>[] adj;
	public static List<int>[] adjr;
    public static bool[] visited;
    //static List<int> metals;
    public static List<int> order;

    static public void topsort(int u) {
    	if (visited[u]) {
    		return;
    	}

    	visited[u] = true;

    	foreach (int v in adjr[u]) {
    		topsort(v);
    	}

    	order.Add(u);
    }

	static public void Main (){
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();

        int nMetals = scanner.NextInt();
        int nLines = scanner.NextInt();

        //adj = new List<int>[MAX_NODES];
        adjr = new List<int>[nMetals];
        visited = new bool[nMetals];
        //metals = new List<int>();
        order = new List<int>();

        
        for(int i = 0; i < nMetals; i++){
        	//adj[i] = new List<int>();
        	adjr[i] = new List<int>();
        }

        while(nLines-- > 0){
        	int a = scanner.NextInt();
        	int b = scanner.NextInt();

        	/*
        	if(adj[a] == null){ adj[a] = new List<int>(); }
        	if(adj[b] == null){ adj[b] = new List<int>(); }
        	if(adjr[a] == null){ adjr[a] = new List<int>(); }
        	if(adjr[b] == null){ adjr[b] = new List<int>(); }
        	*/

        	//adj[a].Add(b);
        	adjr[b].Add(a);
        	//metals.Add(b);
        }
        
        for (int i = 0; i < nMetals; i++) {
        	topsort(i);
        }

        foreach (int m in order) {
        	writer.Write(m);
        	writer.Write(" ");
        }
        writer.Write("\n");
        
        writer.Flush();
    }
}