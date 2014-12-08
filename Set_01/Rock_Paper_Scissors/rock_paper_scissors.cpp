#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdbool.h>
#include <string.h>

int checkWinner(int p1, char m1, int p2, char m2){
    if(m1 == m2){
        return -1;
    } else if(m1 == 's' && m2 == 'p' 
           || m1 == 'p' && m2 == 'r' 
           || m1 == 'r' && m2 == 's'){
        return p1;
    } else {
        return p2;
    }
}

int main(int argc, char** argv) {
    int nPlayers = 0;
    int nGames = 0;

    for(int i = 0; scanf("%d %d\n", &nPlayers, &nGames) > 0; i++){
        if(nPlayers == 0){
            break;
        } else if(i > 0){
            printf("\n");
        }

        float wins[101];
        float losses[101];
        memset(wins, 0, sizeof(wins));
        memset(losses, 0, sizeof(losses));

        nGames = nPlayers * nGames * (nPlayers - 1) / 2;
        //printf("nGames: %d\n", nGames);

        int player1 = 0;
        int player2 = 0;
        char move1[12] = "";
        char move2[12] = "";

        for(int i = 0; i < nGames; i++){
            scanf("%d %s %d %s", &player1, move1, &player2, move2);
            int winner = checkWinner(player1, move1[0], player2, move2[0]);
            if(winner >= 0){
                if(winner == player1){
                    wins[player1] += 1.0;
                    losses[player2] += 1.0;
                } else {
                    wins[player2] += 1.0;
                    losses[player1] += 1.0;
                }
            }
        }

        for(int i = 1; i <= nPlayers; i++){
            if(wins[i] == 0 && losses[i] == 0){
                printf("-\n");
            } else {
                printf("%.3f\n", wins[i]/(wins[i]+losses[i]));
            }
        }
    }
    return (EXIT_SUCCESS);
}
