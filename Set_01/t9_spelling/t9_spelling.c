#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdbool.h>
#include <string.h>

int main(int argc, char** argv) {
    const int messageMaxSize = 1000;
    char buf[1];
    char nMessagesStr[messageMaxSize];

    for(int i = 0; read(0, buf, sizeof(buf)) > 0; i++){
        if(buf[0] == '\n'){
            break;
        }else {
            nMessagesStr[i] = buf[0];
        }
    }

    char *ptr;
    int nMessages;
    nMessages = (int) strtol(nMessagesStr, &ptr, 10);

    char messages[nMessages][messageMaxSize];
    int messagesLen[nMessages];

    for(int i = 0; i < nMessages; i++){
        for(int j = 0; read(0, buf, sizeof(buf)) > 0; j++){
            if(buf[0] == '\n'){
                messages[i][j] = '\0';
                messagesLen[i] = j;
                break;
            }else {
                messages[i][j] = buf[0];
            }
        }
    }

    for(int i = 0; i < nMessages; i++){
        for(int j = 0; j < messagesLen[i]; j++){
            printf("%c", messages[i][j]);
        }
        printf("\n");
    }
    
    return (EXIT_SUCCESS);
}
