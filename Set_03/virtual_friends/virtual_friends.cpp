#include <iostream>
#include <cstdio>
#include <algorithm>
#include <cstring>
#include <string>
#include <cctype>
#include <stack>
#include <queue>
#include <list>
#include <vector>
#include <map>
#include <sstream>
#include <utility>
#include <set>
#include <math.h>

using namespace std;

struct node{
    int id;
    int count;
};

struct union_find {
    vector<node> parent;
    union_find(int n) {
        parent = vector<node>(n);
        
        for (int i = 0; i < n; i++) {
            parent[i].id = i;
            parent[i].count = 1;
        }

    }
    int find(int x) {
        if (parent[x].id == x) {
            return x;
        } else {
            parent[x].id = find(parent[x].id);
            return parent[x].id;
        }
    }
    void unite(int x, int y) {
        int parentX = find(x);
        int parentY = find(y);
        parent[parentY].count += parent[parentX].count;
        parent[parentX].id = parentY;
    }

    int count(int x){
        return parent[find(x)].count;
    }
};

int main(int argc, char** argv) {
    int nCases = 0;
    scanf("%d\n", &nCases);

    for(int i = 0; i < nCases; i++){
        int nFriendships = 0;
        map<string, int> nameIDs;
        int nameID = 1;
        scanf("%d\n", &nFriendships);

        union_find u = union_find(200010);

        for(int j = 0; j < nFriendships; j++){
            string friend1, friend2;

            cin >> friend1 >> friend2;

            //scanf("%s %s\n", friend1.c_str(), friend2.c_str());

            /*
            auto res = nameIDs.insert(make_pair(friend1.c_str(), nameID));

            if (res.second){
                friend1ID = nameID;
                nameID += 1;
            } else {
                friend1ID = (res.first)->second;
            }

            res = nameIDs.insert(make_pair(friend2.c_str(), nameID));
            if (res.second){
                friend2ID = nameID;
                nameID += 1;
            } else {
                friend2ID = (res.first)->second;
            }
            */
            int friend1ID, friend2ID;
            if (!nameIDs[friend1]){
                friend1ID = nameID;
                nameIDs[friend1] = nameID++;
            } else {
                friend1ID = nameIDs[friend1];
            }

            if (!nameIDs[friend2]){
                friend2ID = nameID;
                nameIDs[friend2] = nameID++;
            } else {
                friend2ID = nameIDs[friend2];
            }

            if(u.find(friend1ID) == u.find(friend2ID)){
                printf("%d\n", u.count(friend1ID));                
            } else {
                u.unite(friend1ID, friend2ID);

                printf("%d\n", u.count(friend1ID));
            }

        }
    }

    return (EXIT_SUCCESS);
}

