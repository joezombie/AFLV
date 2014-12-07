#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdbool.h>
#include <vector>
#include <algorithm>
#include <map>
#include <string>

using namespace std;

struct segment_tree {
    segment_tree *left, *right;
    int from, to, value;
    segment_tree(int from, int to)
        : from(from), to(to), left(NULL), right(NULL), value(0) { }
};

segment_tree* build(const vector<int> &arr, int l, int r) {
    if (l > r) return NULL;
    segment_tree *res = new segment_tree(l, r);
    if (l == r) {
        res->value = arr[l];
    } else {
        int m = (l + r) / 2;
        res->left = build(arr, l, m);
        res->right = build(arr, m + 1, r);
        if (res->left != NULL) res->value += res->left->value;
        if (res->right != NULL) res->value += res->right->value;
    }
    return res;
}

int query(segment_tree *tree, int l, int r) {
    if (tree == NULL) return 0;
    if (l <= tree->from && tree->to <= r) return tree->value;
    if (tree->to < l) return 0;
    if (r < tree->from) return 0;
    return query(tree->left, l, r) + query(tree->right, l, r);
}


int main(int argc, char** argv) {
    int nCases = 0;
    scanf("%d\n\n", &nCases);

    for(int i = 0; i < nCases; i++){
        int nSeq = 0;
        int nInteresting = 0;
        scanf("%d\n\n", &nSeq);

        std::vector<int> arr(nSeq, 0);

        int number;
        for(int j = 0; j < nSeq; j++){
            scanf("%d", &number);
            arr[j] = number;
        }

        segment_tree *tree = build(arr, 0, nSeq - 1);

        for(int j = 0; j < nSeq; j++){
            for(int k = j; k < nSeq; k++){
                if(query(tree, j, k) > 47){
                    break;
                }else if(query(tree, j, k) == 47){
                    nInteresting += 1;
                    break;
                }
            }
        }

        printf("%d\n", nInteresting);
    }

    return (EXIT_SUCCESS);
}

