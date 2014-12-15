using System;
using System.Globalization;
using System.Collections.Generic;
using Kattis.IO;

public class Program {
    //public static List<edge>[] adj;
    public static EdgeComparer edgeComparer;

    public struct union_find {
        public int[] parent;
        public union_find(int n) {
            parent = new int[n];
            for (int i = 0; i < n; i++) {
                parent[i] = i;
            }
        }
        public int find(int x) {
            if (parent[x] == x) {
                return x;
            } else {
                parent[x] = find(parent[x]);
                return parent[x];
            }
        }
        public void unite(int x, int y) {
            parent[find(x)] = find(y);
        }
    }

    public struct edge {
        public int u, v;
        public double weight;
        public edge(int _u, int _v, double _w) {
            u = _u;
            v = _v;
            weight = _w;
        }

        override public string ToString(){
        	return "u:" + (u + 1).ToString() +
        		   " v:" + (v + 1).ToString() +
        		   " w:" + weight.ToString();
        }
    }

    public class EdgeComparer: IComparer<edge>{
        public int Compare(edge a, edge b){
            if(a.weight < b.weight){
                return -1;
            } else {
                return 1;
            }
        }
    }

    public bool edge_cmp(edge a, edge b) {
        return a.weight < b.weight;
    }

    static public List<edge> mst(int n, List<edge> edges) {
        union_find uf = new union_find(n);
        //sort(edges.begin(), edges.end(), edge_cmp);
        edges.Sort(edgeComparer);
        List<edge> res = new List<edge>();
        for (int i = 0; i < edges.Count; i++) {
            int u = edges[i].u,
            v = edges[i].v;
            if (uf.find(u) != uf.find(v)) {
                uf.unite(u, v);
                res.Add(edges[i]);
            }
        }
        return res;
    }

    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        edgeComparer = new EdgeComparer();
        List<edge> edges = new List<edge>();

        int n = scanner.NextInt();
        int m = scanner.NextInt();

        while(m-- > 0){
			edges.Add(
				new edge(
					scanner.NextInt() - 1,
		  		   	scanner.NextInt() - 1,
		  		   	1.0
	  		   	)
  		   );        	
            
        }

        double ans = 0;
        foreach (edge e in mst(n, edges)) {
            writer.WriteLine(e);
        }

        writer.WriteLine(ans);
        
        writer.Flush();
    }
}