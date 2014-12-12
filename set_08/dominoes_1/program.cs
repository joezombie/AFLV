using System;
using System.Collections.Generic;
using Kattis.IO;

public class Program
{
    const int MAX_TILES = 100000;
    static List<int>[] adj;
    static List<int>[] adjb;
    static bool[] visited;

    static void dfs(int u) {
        if (visited[u]) {
            return;
        }
        visited[u] = true;
        for (int i = 0; i < adj[u].Count; i++) {
            int v = adj[u][i];
            dfs(v);
        }
    }

    static void rdfs(int u) {
        if (visited[u]) {
            return;
        }
        visited[u] = true;
        for (int i = 0; i < adjb[u].Count; i++) {
            int v = adjb[u][i];
            rdfs(v);
        }
    }
    
    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        
        adj = new List<int>[MAX_TILES];
        adjb = new List<int>[MAX_TILES];
        visited = new bool[MAX_TILES];

        int nCases = scanner.NextInt();

        while(nCases-- > 0){
            int nTiles = scanner.NextInt();
            int nLines = scanner.NextInt();

            for(int i = 0; i < nTiles; i++){
                adj[i] = new List<int>();
                adjb[i] = new List<int>();
                visited[i] = false;
            }

            while(nLines-- > 0){
                int x = scanner.NextInt() - 1;
                int y = scanner.NextInt() - 1;
                adj[x].Add(y);
                adjb[y].Add(x);
            }

            for (int u = 0; u < nTiles; u++) {
                dfs(u);
            }

            writer.WriteLine("END");    


            
        }
        
        writer.Flush();
    }
}