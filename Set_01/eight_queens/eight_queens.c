#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

int main(int argc, char** argv) {

	char buf[1];

    while(read(0, buf, sizeof(buf)) > 0){
        printf(buf);
    }

    return (EXIT_SUCCESS);
}