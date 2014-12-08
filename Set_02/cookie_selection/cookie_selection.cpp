#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdbool.h>
#include <vector>
#include <algorithm>
#include <map>

using namespace std;

struct findMedian{
    map<int, int> medians;
    int count = 0;
    void insert(int x){
        if(medians.find(x) == medians.end()){
            medians[x] = 1;
        } else {
            medians[x] += 1;
        }
        count += 1;
    }

    int pop(){
        int i = count % 2 == 0 ? (count / 2) + 1 : (count + 1) / 2;
        //printf("count:%d i:%d\n", count, i);
        int n = 0;
        int result = 0;
        for(auto it = medians.begin(); it != medians.end(); it++){
            //printf("%d %d\n", it->first, it->second);
            n += it->second;
            if(n >= i){
                //result = it->first;
                it->second -= 1;
                count -= 1;
                result = it->first;
                
                if(it->second < 1){
                    medians.erase(it);
                }
                
                break;
                
            }
        }
        return result;
    }
};

int main(int argc, char** argv) {
    findMedian cookies;
    char buf[10];
    int n = 0;
    int cookie = 0;
    bool notInserted = true;

    while(scanf("%s\n", buf) != EOF){       
        if(buf[0] == '#'){
            //printf("pop\n");
            printf("%d\n", cookies.pop());
        } else {
            //printf("insert\n");
            cookies.insert(atoi(buf));
        }
    }

    return (EXIT_SUCCESS);
}

