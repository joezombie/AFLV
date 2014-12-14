using System;
using System.Globalization;
using System.Collections.Generic;
using Kattis.IO;

public class Program {
    public static List<edge>[] adj;
    public static float[] dist;

    public struct edge {
        public int u, v;
        public float weight;
        public edge(int _u, int _v, float _w) {
            u = _u;
            v = _v;
            weight = _w;
        }
    }

    static public void bellman_ford(int n, int start) {
        dist[start] = 1.0f;
        for (int i = 0; i < n - 1; i++) {
            for (int u = 0; u < n; u++) {
                for (int j = 0; j < adj[u].Count; j++) {
                    int v = adj[u][j].v;
                    float w = adj[u][j].weight;
                    dist[v] = Math.Max(dist[v], w * dist[u]);
                }
            }
        }
    }

    static void dijkstra(int start) {
        dist[start] = 1.0f;
        priority_queue<pair<int, int>, vector<pair<int, int> >, greater<pair<int, int> > > pq;
        pq.push(make_pair(dist[start], start));
        while (!pq.empty()) {
            int u = pq.top().second;
            pq.pop();
            for (int i = 0; i < adj[u].size(); i++) {
                int v = adj[u][i].v;
                int w = adj[u][i].weight;
                if (w + dist[u] < dist[v]) {
                    dist[v] = w + dist[u];
                    pq.push(make_pair(dist[v], v));
                }
            }
        }
    }

    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();

        while(scanner.HasNext()){
        	int nIntersections = scanner.NextInt();
        	int nCorridors = scanner.NextInt();
            if(nIntersections == 0 && nCorridors == 0){
                break;
            }

            adj = new List<edge>[nIntersections];
            dist = new float[nIntersections];
            
            for(int i = 0; i < nIntersections; i++){
                adj[i] = new List<edge>();
                dist[i] = 0;
            }

        	for(int i = 0; i < nCorridors; i++){
                int x = scanner.NextInt();
                int y = scanner.NextInt();
                float f = float.Parse(scanner.Next(), CultureInfo.InvariantCulture);
                adj[x].Add(new edge(x, y, f));
                adj[y].Add(new edge(y, x, f));
        	}

            bellman_ford(nIntersections, 0);

            writer.WriteLine(String.Format(CultureInfo.InvariantCulture, "{0:0.0000}", dist[nIntersections - 1]));
        }
        
        writer.Flush();
    }
}