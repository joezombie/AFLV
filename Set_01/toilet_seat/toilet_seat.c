#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdbool.h>

int main(int argc, char** argv) {
    const int inputMaxSize = 1000;
	char buf[1];
    char input[inputMaxSize];
    int nInput;
    int p1Changes = 0;
    int p2Changes = 0;
    int p3Changes = 0;

    for(int i = 0; read(0, buf, sizeof(buf)) > 0; i++){
        if(buf[0] == '\n'){
            break;
        } else {
            input[i] = buf[0];
            nInput += 1;
        }
    }

    for(int i = 1; i < nInput; i++){
        switch(input[i]){
            case 'U':
                p2Changes += 2;
                break;
            case 'D':
                p1Changes += 2;
                break;
        }
        if(input[i] != input[i-1]){
            p3Changes += 1;
        }
    }
    
    if(input[0] == input[1]){
        switch(input[1]){
            case 'U':
                p2Changes -= 1;
                break;
            case 'D':
                p1Changes -= 1;
                break;
        }
    } else {
        switch(input[1]){
            case 'U':
                p1Changes += 1;
                break;
            case 'D':
                p2Changes += 1;
                break;
        }
    }

    printf("%d\n%d\n%d\n", p1Changes, p2Changes, p3Changes);

    return (EXIT_SUCCESS);
}

