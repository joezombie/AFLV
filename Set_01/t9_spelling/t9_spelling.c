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

    printf("%d\n%d\n%d\n", p1Changes, p2Changes, p3Changes);

    return (EXIT_SUCCESS);
}

