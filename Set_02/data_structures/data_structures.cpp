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
#include <bitset>

using namespace std;

int main(int argc, char** argv) {
    
    int nCases = 0;
    while(scanf("%d\n", &nCases) != EOF){
        
        stack<short> theStack;
        queue<short> theQueue;
        priority_queue<short> thePriorityQueue;
        bitset<3> code;
        code.set();

        for(int i = 0; i < nCases; i++){
            char op;
            short x;
            scanf("%hhd %hd", &op, &x);
            

            if(op == 1) {
                theStack.push(x);
                theQueue.push(x);
                thePriorityQueue.push(x);
            } else if(op == 2) {
                //printf("code:%d\n", code);
                if(code.any()){
                    if(theStack.empty()){
                        code[0] = 0;
                    } else {
                        if(x != theStack.top()){
                            code[0] = 0;
                        }
                        theStack.pop();
                    }
                    
                    if(theQueue.empty()){
                        code[1] = 0;
                    } else {
                        if(x != theQueue.front()){
                            code[1] = 0;
                        }
                        theQueue.pop();
                    }

                    if(thePriorityQueue.empty()){
                        code[2] = 0;
                    } else {
                        if(x != thePriorityQueue.top()){
                            code[2] = 0;
                        }
                        thePriorityQueue.pop();
                    }
                }
                
            }
        }

        switch(code.to_ulong()){
            case 0:
                printf("impossible\n");
                break;
            case 1:
                printf("stack\n");
                break;
            case 2:
                printf("queue\n");
                break;
            case 4:
                printf("priority queue\n");
                break;
            default:
                printf("not sure\n");
        }
        
    }  

    return (EXIT_SUCCESS);
}

