#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdbool.h>
#include <vector>
#include <algorithm>


using namespace std;

int main(int argc, char** argv) {
    std::vector<int> cookies;
    char buf[10];
    int n = 0;
    int cookie = 0;
    bool notInserted = true;

    while(scanf("%s\n", buf) != EOF){       
        if(buf[0] == '#'){          
            if(cookies.size() % 2 == 0){
                n = (cookies.size() / 2);
            } else {
                n = (cookies.size() - 1) / 2;
            }
            printf("%d\n", cookies[n]);
            cookies.erase(cookies.begin() + n);
        } else {
            cookie = atoi(buf);
            notInserted = true;
            for(int i = 0; i < cookies.size(); i++){
                if(cookies[i] > cookie){
                    cookies.insert(cookies.begin() + i, cookie);
                    notInserted = false;
                }
            }
            if(notInserted){
                cookies.push_back(cookie);    
            }
            
        }
    }

    return (EXIT_SUCCESS);
}

