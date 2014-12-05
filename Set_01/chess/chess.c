#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdbool.h>
#include <string.h>

struct position{
    int x;
    int y;
};

struct vector{
    int x;
    int y;
};

int getXNr(char c){
    return 8 - (c - 'A');
}

char getXChar(int x){
    return 8 - x + 'A';
}

bool isPositionValid(struct position pos){
    return (pos.x <= 8 && pos.x > 0 && pos.y <= 8 && pos.y > 0);
}

int main(int argc, char** argv) {
    int nCases = 0;
    scanf("%d\n", &nCases);

    int lines[8][8] = {
        {0,},
    };

    for(int i = 0; i < nCases; i++){
        bool possible = true;
        char x1 = '\0';
        char x2 = '\0';
        struct position start = {0, 0};
        struct position end = {0, 0};
        struct position moves[4];
        int nMoves = 0;

        scanf("%c %d %c %d\n", &x1, &start.y, &x2, &end.y);
        start.x = getXNr(x1);
        end.x = getXNr(x2);

        if(start.x == end.x && start.y == end.y){
            possible = true;
        } else if((start.x + start.y) % 2 != (end.x + end.y) % 2){
            possible = false;
        } else {            
            struct vector direction = {0, 0};
            struct vector oldDirection = {0, 0};
            struct position currPosition = {start.x, start.y};
            struct position nextPosition = {start.x, start.y};

            if(currPosition.x - end.x > 0){
                direction.x = -1;
            } else {
                direction.x = 1;
            }
            if(currPosition.y - end.y > 0){
                direction.y = -1;
            } else {
                direction.y = 1;
            }

            printf("direction: %d %d\n", direction.x, direction.y);
            printf("start: %c %d\n", getXChar(start.x), start.y);
            printf("end: %c %d\n", getXChar(end.x), end.y);
            printf("nextP: %c %d\n\n", getXChar(nextPosition.x), nextPosition.y);

            while(nMoves < 4){
                oldDirection = direction;

                if(currPosition.x == end.x && currPosition.y == end.y){
                    possible = true;
                    break;
                }
                
                nextPosition.x += direction.x;
                nextPosition.y += direction.y;
                printf("direction: %d %d\n", direction.x, direction.y);
                printf("next: %c %d\n", getXChar(nextPosition.x), nextPosition.y);
                if(isPositionValid(nextPosition)){
                    currPosition = nextPosition;
                }else {
                    if(currPosition.x - end.x > 0){
                        direction.x = -1;
                    } else {
                        direction.x = 1;
                    }
                    if(currPosition.y - end.y > 0){
                        direction.y = -1;
                    } else {
                        direction.y = 1;
                    }
                    moves[nMoves] = currPosition;
                    nMoves += 1;
                    nextPosition = currPosition;
                }
            }
        }

        if(possible){
            printf("%d %c %d",nMoves, getXChar(start.x), start.y);
            for(int i = 0; i < nMoves; i++){
                printf(" %c %d", getXChar(moves[i].x), moves[i].y);
            }
            printf("\n");
        } else {
            printf("Impossible\n");
        }
    }

    return (EXIT_SUCCESS);
}
