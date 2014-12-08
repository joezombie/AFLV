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
    scanf("%d\n", &nCases);
    int nPhoneNr = 0;
    while(scanf("%d\n", &nPhoneNr) != EOF){
        
        //scanf("%d\n", &nPhoneNr);
        char phoneNr[nPhoneNr][11];
        bool possible = true;

        for(int i = 0; i < nPhoneNr && possible; i++){
            scanf("%s\n", phoneNr[i]);
            if(possible){
                if(i > 0){
                    for(int j = 0; j < i && possible; j++){
                        for(int k = 0; ; k++){
                            //printf("i:%d j:%d k:%d\n", i, j, k);
                            //printf("%s %s\n", phoneNr[i], phoneNr[j]);
                            //printf("%c %c\n", phoneNr[i][k], phoneNr[j][k]);
                            if(phoneNr[i][k] == '\0' && phoneNr[j][k] == '\0'){
                                //printf("both end\n");
                                possible = false;
                                break;
                            }
                            if(phoneNr[i][k] == '\0'){
                                //printf("left ends\n");
                                possible = false;
                                break;
                            }
                            if(phoneNr[j][k] == '\0'){
                                //printf("right ends\n");
                                possible = false;
                                break;
                            }
                            if(phoneNr[j][k] != phoneNr[i][k]){
                                //printf("not equal\n");
                                break;
                            }
                        }
                    }
                }
            }
        }

        if(possible){
            printf("YES\n");
        } else {
            printf("NO\n");
        }
    }  

    return (EXIT_SUCCESS);
}

