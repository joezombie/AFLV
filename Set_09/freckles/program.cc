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
#include <algorithm>    // std::sort
#include <iomanip>      // std::setprecision

using namespace std; 

struct edge {
    int u, v;
    double weight;
    edge(int _u, int _v, double _w) {
        u = _u;
        v = _v;
        weight = _w;
    }
};

struct point {
    double x, y;
    point(){
        x = 0.0f;
        y = 0.0f;
    }
    point(double _x, double _y){
        x = _x;
        y = _y;
    }
};

struct union_find {
    vector<int> parent;
    union_find(int n) {
        parent = vector<int>(n);
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
    }
    int find(int x) {
        if (parent[x] == x) {
            return x;
        } else {
            parent[x] = find(parent[x]);
            return parent[x];
        }
    }
    void unite(int x, int y) {
        parent[find(x)] = find(y);
    }
};

bool edge_cmp(const edge &a, const edge &b) {
    return a.weight < b.weight;
}

vector<edge> mst(int n, vector<edge> edges) {
    union_find uf(n);
    sort(edges.begin(), edges.end(), edge_cmp);
    vector<edge> res;
    for (int i = 0; i < edges.size(); i++) {
        int u = edges[i].u,
        v = edges[i].v;
        if (uf.find(u) != uf.find(v)) {
            uf.unite(u, v);
            res.push_back(edges[i]);
        }
    }
    return res;
}

vector<edge> edges;

int main(void) {
    int nCases;
    scanf("%d\n\n", &nCases);
    point points[1010];

    while(nCases--){
        int n;
        scanf("%d\n", &n);     

        for(int i = 0; i < n; i++){
            double x, y;
            scanf("%lf %lf\n", &x, &y);
            points[i] = point(x, y);
        }

        edges.clear();
        for(int i = 0; i < n; i++){
            for(int j = i + 1; j < n; j++){
                double f = sqrt(
                    pow(points[i].x - points[j].x, 2) + 
                    pow(points[i].y - points[j].y, 2)
                );
                edges.push_back(edge(i, j, f));
                //edges.push_back(edge(j, i, f));
            }
        }

        vector<edge> m = mst(n, edges);

        double ans = 0.0;
        for(int i = 0; i < m.size(); i++){
            ans += m[i].weight;
        }

        printf("%.2lf\n", ans);
    }


    return 0;
}
