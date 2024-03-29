#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdbool.h>
#include <set>


int main(int argc, char** argv) {
	
    while(true){
        int nJack, nJill;
        int both = 0;
        scanf("%d %d\n", &nJack, &nJill);

        std::set<int> cds;

        if(nJack == 0 && nJill == 0){
            break;
        }

        for(int i = 0; i < nJack; i++){
            int cd = 0;
            scanf("%d\n", &cd);
            cds.insert(cd);
        }
        for(int i = 0; i < nJill; i++){
            int cd = 0;
            scanf("%d\n", &cd);
            if(cds.find(cd) != cds.end()){
                both += 1;
            }
        }
        printf("%d\n", both);
    }

    return (EXIT_SUCCESS);
}

