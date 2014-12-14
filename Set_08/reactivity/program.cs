using System;
using System.Collections.Generic;
using Kattis.IO;

public class Program
{
	public static List<int>[] adj;
    public static bool[] visited;
    public static List<int> order;

    static public void topsort(int u) {
    	if (visited[u]) {
    		return;
    	}

    	visited[u] = true;

    	foreach (int v in adj[u]) {
    		topsort(v);
    	}

    	order.Add(u);
    }

	static public void Main (){
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();

        int nMetals = scanner.NextInt();
        int nLines = scanner.NextInt();

        adj = new List<int>[nMetals];
        visited = new bool[nMetals];
        order = new List<int>();

        
        for(int i = 0; i < nMetals; i++){
        	adj[i] = new List<int>();
        }

        while(nLines-- > 0){
        	int a = scanner.NextInt();
        	int b = scanner.NextInt();
        	adj[b].Add(a);
        }
        
        for (int i = 0; i < nMetals; i++) {
        	topsort(i);
        }

        bool complete = true;
        for (int i = 1; i < order.Count; i++){
            if(!adj[order[i]].Contains(order[i-1])){
                complete = false;
            }
        }

        if(complete){
            foreach (int m in order) {
            	writer.Write(m);
            	writer.Write(" ");
            }
            writer.Write("\n");
        } else {
            /*/ Remove
            foreach (int m in order) {
                writer.Write(m);
                writer.Write(" ");
            }
            */
            writer.Write("back to the lab\n");
        }
        
        
        writer.Flush();
    }
}