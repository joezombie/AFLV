using System;
using System.Globalization;
using System.Collections.Generic;
using Kattis.IO;

public class Program {
    public static List<edge>[] adj;
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

    public struct xy {
        public xy(float x, float y){
            this.x = x;
            this.y = y;
        }
        override public string ToString(){
            return x.ToString() + "," + y.ToString();
        }
        public float x;
        public float y;
    }

    public struct edge {
        public int u, v;
        public float weight;
        public edge(int _u, int _v, float _w) {
            u = _u;
            v = _v;
            weight = _w;
        }
    }

    public class EdgeComparer: IComparer<edge>{
        public int Compare(edge a, edge b){
            if(a.weight < b.weight){
                return 1;
            } else {
                return -1;
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
        
        int nCases = scanner.NextInt();

        while(nCases-- > 0){
            int nFreckles = scanner.NextInt();
            adj = new List<edge>[nFreckles];
            for(int i = 0; i < nFreckles; i++){
                adj[i] = new List<edge>();
            }

            xy[] points = new xy[nFreckles];

        	for(int i = 0; i < nFreckles; i++){
                points[i] = new xy(
                    float.Parse(scanner.Next(), CultureInfo.InvariantCulture),
                    float.Parse(scanner.Next(), CultureInfo.InvariantCulture)
                );
        	}

            for(int i = 0; i < nFreckles; i++){
                for(int j = i + 1; j < nFreckles; j++){
                    float f = (float)Math.Sqrt(
                        Math.Pow(points[i].x - points[j].x, 2) + 
                        Math.Pow(points[i].y - points[j].y, 2) 
                    );
                    
                    adj[i].Add(new edge(i, j, f));
                    adj[j].Add(new edge(j, i, f));
                }
            }

            float ans = float.MaxValue;
            for(int i = 0; i < nFreckles; i++){
                float cost = 0.0f;
                foreach (edge e in mst(nFreckles, adj[i])) {
                     cost += e.weight;
                }
                ans = Math.Min(ans, cost);
            }
                writer.WriteLine(String.Format(CultureInfo.InvariantCulture, "{0:0.00}", ans));
        }
        
        writer.Flush();
    }
}