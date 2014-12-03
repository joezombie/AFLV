#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdbool.h>
#include <string.h>



int getNrPresses(char c){
    int result = 0;
    switch(c){
        case 'a':
        case 'd':
        case 'g':
        case 'j':
        case 'm':
        case 'p':
        case 't':
        case 'w':
        case ' ':
            result = 1;
            break;
        case 'b':
        case 'e':
        case 'h':
        case 'k':
        case 'n':
        case 'q':
        case 'u':
        case 'x':
            result = 2;
            break;
        case 'c':
        case 'f':
        case 'i':
        case 'l':
        case 'o':
        case 'r':
        case 'v':
        case 'y':
            result = 3;
            break;
        case 's':
        case 'z':
            result = 4;
            break;
        default:
            result = -1;
            break;
    }

    return result;
}

int getKeyNr(char c){
    int result = -1;

    switch(c){
        case 'a':
        case 'b':
        case 'c':
            result = 2;
            break;
        case 'd':
        case 'e':
        case 'f':
            result = 3;
            break;
        case 'g':
        case 'h':
        case 'i':
            result = 4;
            break;
        case 'j':
        case 'k':
        case 'l':
            result = 5;
            break;
        case 'm':
        case 'n':
        case 'o':
            result = 6;
            break;
        case 'p':
        case 'q':
        case 'r':
        case 's':
            result = 7;
            break;
        case 't':
        case 'u':
        case 'v':
            result = 8;
            break;
        case 'w':
        case 'x':
        case 'y':
        case 'z':
            result = 9;
            break;
        case ' ':
            result = 0;
            break;
    }

    return result;
}

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
        printf("Case #%d: ", i + 1);
        for(int j = 0; j < messagesLen[i]; j++){
            int keyNr = getKeyNr(messages[i][j]);
            for(int k = 0; k < getNrPresses(messages[i][j]); k++){
                printf("%d", keyNr);
            }
            if(getKeyNr(messages[i][j]) == getKeyNr(messages[i][j+1])){
                    printf(" ");
            }
        }
        printf("\n");
    }
    
    return (EXIT_SUCCESS);
}
