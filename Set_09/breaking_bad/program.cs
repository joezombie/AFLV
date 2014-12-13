using System;
using System.Collections.Generic;
using Kattis.IO;

public class Program
{
	static string[] items;
	static Dictionary<string, int> itemIDs;

	static List<int>[] adj;
	static int[] side;

	static bool is_bipartite = true;

	static void check_bipartite(int u) {
		for (int i = 0; i < adj[u].Count; i++) {
			int v = adj[u][i];
			if (side[v] == -1) {
				side[v] = 1 - side[u];
				check_bipartite(v);
			} else if (side[u] == side[v]) {
				is_bipartite = false;
			}
		}
	}

    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        
        int nItems = scanner.NextInt();
        items = new string[nItems];
     	itemIDs = new Dictionary<string, int>();

        adj = new List<int>[nItems];
        for(int i = 0; i < nItems; i++){
        	adj[i] = new List<int>();
        }

        side = new int[nItems];
        for(int i = 0; i < nItems; i++){
        	side[i] = -1;
        }

        for(int i = 0; i < nItems; i++){
        	items[i] = scanner.Next();
        	itemIDs.Add(items[i], i);
        }

        int nPairs = scanner.NextInt();

        for(int i = 0; i < nPairs; i++){
        	string item1 = scanner.Next();
        	string item2 = scanner.Next();
        	adj[itemIDs[item1]].Add(itemIDs[item2]);
        	adj[itemIDs[item2]].Add(itemIDs[item1]);
        }

        for (int u = 0; u < nItems; u++) {
			if (side[u] == -1) {
				side[u] = 0;
				check_bipartite(u);
			}
		}

		if(is_bipartite){
			for(int i = 0; i < 2; i++){
				for(int j = 0; j < nItems; j++){
					if(side[j] == i){
						writer.Write(items[j]);
						writer.Write(" ");
					}
				}
				writer.Write("\n");
			}
		} else {
			writer.WriteLine("impossible");
		}

        writer.Flush();
    }
}