#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdbool.h>
#include <string.h>

char HANDS[3][9] = {
    {"paper"},
    {"rock"},
    {"scissors"}
};

int main(int argc, char** argv) {
    int nPlayers = 0;
    int nGames = 0;
    while(scanf("%d %d\n", &nPlayers, &nGames) > 0){
        if(nPlayers == 0){
            break;
        }
        char moves[nGames][nPlayers][9];

        for(int i = 0; i < nGames; i++){
            for(int j = 0; j < nPlayers; j++){
                int player = 0;
                scanf("%d ", &player);            
                scanf("%s", moves[i][player - 1]);
            }
        }

        for(int i = 0; i < nGames; i++){
            for(int j = 0; j < nPlayers; j++){
                printf("%d %s ", j + 1, moves[i][j]);
            }
            printf("\n");
        }
    }
    return (EXIT_SUCCESS);
}
