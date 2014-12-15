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
#include <cstdlib>
#include <stack>
#include <queue>
#include <set>

using namespace std;

struct flow_network {

    struct edge {
        int u, v, cap;
        edge *rev;
        bool forward;
        edge(int _u, int _v, int _cap, bool forw)
            : u(_u), v(_v), cap(_cap), forward(forw) { }
    };

    struct edge_cmp {
	    bool operator() (const edge* a, const edge* b) const{
	        if(a->u == b->u){
	        	return a->v < b->v;
	        }
	        return a->u < b->u;
	    }
	};

    int n, f;
    vector<vector<edge*> > adj;
    set<edge*, edge_cmp> path;

    flow_network(int _n) : n(_n), adj(_n) { }

    void add_edge(int u, int v, int cap) {
        edge *e = new edge(u, v, cap, true);
        edge *rev = new edge(v, u, 0, false);
        e->rev = rev;
        rev->rev = e;
        adj[u].push_back(e);
        adj[v].push_back(rev);
    }

     int augment(int s, int t) {
        vector<edge*> back(n, NULL);
        queue<int> Q;
        Q.push(s);
        back[s] = (edge*)1;
        while (!Q.empty()) {
            int u = Q.front(); Q.pop();
            for (int i = 0; i < adj[u].size(); i++) {
                int v = adj[u][i]->v;
                if (back[v] == NULL && adj[u][i]->cap > 0) {
                    back[v] = adj[u][i];
                    Q.push(v);
                }
            }
        }

        if (back[t] == NULL)
            return 0;

        stack<edge*> S;
        S.push(back[t]);
        int bneck = back[t]->cap;

        while (S.top()->u != s) {
            S.push(back[S.top()->u]);
            bneck = min(bneck, S.top()->cap);
        }

        while (!S.empty()) {
        	path.insert(S.top());
            S.top()->cap -= bneck;
            S.top()->rev->cap += bneck;
            S.pop();
        }

        return bneck;
    }

     int max_flow(int source, int sink) {
        int flow = 0;
        while (true) {
            int f = augment(source, sink);
            if (f == 0) {
                break;
            }

            flow += f;
        }
        f = flow;
        return flow;
    }

    void print_path(){
    	printf("%u %u %lu\n", n, f, path.size());
        for(auto e : path){
        	printf("%u %u %u\n", e->u, e->v, e->rev->cap);
        }
    }
};

int main() {
	int n, m, s, t;
	scanf("%d %d %d %d\n", &n, &m, &s, &t);
	flow_network network = flow_network(n);

	while(m--){
		int u, v;
		int c;
		scanf("%d %d %d\n", &u, &v, &c);
		network.add_edge(u, v, c);
	}

	int f = network.max_flow(s, t);
	
	network.print_path();

    return 0;
}
