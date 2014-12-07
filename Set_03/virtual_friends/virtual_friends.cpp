#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdbool.h>
#include <vector>
#include <algorithm>
#include <map>
#include <string>

using namespace std;

struct union_find {
    vector<int> parent;
    vector<int> parentCount;
    union_find(int n) {
        parent = vector<int>(n);
        parentCount = vector<int>(n);
        for (int i = 0; i < n; i++) {
            parent[i] = i;
            parentCount[i] = 1;
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
        int parentX = find(x);
        int parentY = find(y);
        parent[parentX] = parentY;
        parentCount[parentY] += parentCount[parentX];
    }
    int count(int x){
        return parentCount[find(x)];
    }
};

int main(int argc, char** argv) {
    int nCases = 0;
    scanf("%d\n", &nCases);
    map<string, int> nameIDs;

    for(int i = 0; i < nCases; i++){
        int nFriendships = 0;
        int nameID = 1;
        scanf("%d\n", &nFriendships);
        string friend1;
        string friend2;
        int friend1ID;
        int friend2ID;

        union_find u = union_find(nFriendships);

        for(int j = 0; j < nFriendships; j++){
            scanf("%s %s\n", friend1.c_str(), friend2.c_str());
            printf("%s %s\n", friend1.c_str(), friend2.c_str());

            auto res = nameIDs.insert(make_pair(friend1.c_str(), nameID));

            if (res.second){
                printf("created\n");
                friend1ID = nameID;
                nameID += 1;
            } else {
                printf("Exists\n");
                friend1ID = (res.first)->second;
            }

            res = nameIDs.insert(make_pair(friend2.c_str(), nameID));
            if (res.second){
                printf("created\n");
                friend2ID = nameID;
                nameID += 1;
            } else {
                printf("Exists\n");
                friend2ID = (res.first)->second;
            }

            u.unite(friend1ID, friend2ID);

            printf("%d %d\n", friend1ID, friend2ID);
            printf("Count %d\n", u.count(friend1ID));
        }
    }

    return (EXIT_SUCCESS);
}

