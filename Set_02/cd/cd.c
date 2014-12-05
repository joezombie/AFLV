#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdbool.h>


int main(int argc, char** argv) {
	
    while(true){
        int nJack, nJill;
        scanf("%d %d\n", &nJack, &nJill);
        
        if(nJack == 0 && nJill == 0){
            break;
        } else if(nJack > nJill)

        for(int i = 0; i < nJack + nJill; i++){
            int cd = 0;
            scanf("%d\n", &cd);
            printf("cd %d\n", cd);
        }
    }

    return (EXIT_SUCCESS);
}

