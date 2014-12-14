#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdbool.h>
#include <string.h>
#include <utility>
#include <vector>
#include <limits>
#include <math.h>
#include <iostream>       // std::cout
#include <queue>          // std::priority_queue
#include <functional>     // std::greater

using namespace std; 

struct edge {
    int u, v;
    float weight;
    edge(int _u, int _v, float _w) {
        u = _u;
        v = _v;
        weight = _w;
    }
};

vector<edge> adj[10001];
vector<float> dist(10001, 0.0f);

void dijkstra(int start) {
    dist[start] = 1.0f;
    //priority_queue< pair<float, int>, vector<pair<float, int> >, greater<pair<float, int>> > pq;
    priority_queue< pair<float, int> > pq;
    pq.push(make_pair(dist[start], start));
    while (!pq.empty()) {
        int u = pq.top().second;
        pq.pop();
        for (int i = 0; i < adj[u].size(); i++) {
            int v = adj[u][i].v;
            float w = adj[u][i].weight;
            if (w * dist[u] > dist[v]) {
                dist[v] = w * dist[u];
                pq.push(make_pair(dist[v], v));
            }
        }
    }
}

void bellman_ford(int n, int start) {
    dist[start] = 1.0f;
    for (int i = 0; i < n - 1; i++) {
        for (int u = 0; u < n; u++) {
            for (int j = 0; j < adj[u].size(); j++) {
                int v = adj[u][j].v;
                float w = adj[u][j].weight;
                dist[v] = max(dist[v], w * dist[u]);
            }
        }
    }
}

int main(void) {
    while(true){
        int n;
        int m;
        scanf("%d %d\n", &n, &m);
        if(n == 0 && m == 0){ break; };

        for(int i = 0; i < n; i++){
            adj[i].clear();
            dist[i] = 0.0f;
        }        

        for(int i = 0; i < m; i++){
            int x, y;
            float f;
            scanf("%d %d %f\n", &x, &y, &f);
            adj[x].push_back(edge(x, y, f));
            adj[y].push_back(edge(y, x, f));
        }

        dijkstra(0);
        //bellman_ford(n, 0);

        printf("%.4f\n", dist[n - 1]);
    }


    return 0;
}
