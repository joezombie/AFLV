using System;
using System.Collections.Generic;
using Kattis.IO;

public class Program
{
    const int MAX_TILES = 100000;
    static public List<int>[] adj;

    static int[] low;
    static int[] num;
    static bool[] incomp;
    static int curnum = 0;
    static Stack<int> comp;
    static int[] sccCount;

    static void scc(int u) {
        comp.Push(u);
        incomp[u] = true;
        low[u] = num[u] = curnum++;

        for (int i = 0; i < adj[u].Count; i++) {
            int v = adj[u][i];
            if (num[v] == -1) {
                scc(v);
                low[u] = Math.Min(low[u], low[v]);
            } else if (incomp[v]) {
                low[u] = Math.Min(low[u], num[v]);
            }
        }
        if (num[u] == low[u]) {
            Console.Write("comp: ");
            while (true) {
                int cur = comp.Pop();
                incomp[cur] = false;
                //Console.Write(cur.ToString() + ", ");
                if (cur == u) {
                    break;
                }
            }
            //Console.WriteLine();
        }
    }
    
    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        
        adj = new List<int>[MAX_TILES];
        low = new int[MAX_TILES];
        num = new int[MAX_TILES];
        incomp = new bool[MAX_TILES];
        comp = new Stack<int>();

        int nCases = scanner.NextInt();

        while(nCases-- > 0){
            int nTiles = scanner.NextInt();
            int nLines = scanner.NextInt();

            sccCount = 0;

            for(int i = 0; i < nTiles; i++){
                adj[i] = new List<int>();
                num[i] = -1;
                incomp[i] = false;
            }

            while(nLines-- > 0){
                int x = scanner.NextInt() - 1;
                int y = scanner.NextInt() - 1;
                adj[x].Add(y);
            }

            for (int i = 0; i < nTiles; i++) {
                if (num[i] == -1) {
                    scc(i);
                }
            }

            writer.WriteLine(curnum);
        }
        
        writer.Flush();
    }
}