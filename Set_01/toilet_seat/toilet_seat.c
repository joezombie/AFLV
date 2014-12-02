#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdbool.h>

struct queen{
	short row;
    short column;
};

int main(int argc, char** argv) {
	char buf[1];
    const int nQueens = 8;
    const int nRows = 8;
    const int nColumns = 8;
	struct queen queens[nQueens];
    bool valid = true;

    for(int i=0, j=0, q=0; read(0, buf, sizeof(buf)) > 0;){
    	switch(buf[0]){
    		case '\n':
    			i++;
    			j = 0;
    			break;
    		case '*':
                queens[q].row = i;
                queens[q].column = j;
                q += 1;
			case '.':
			default:
				j++;
    	}
    }

    for(int i = 0; i < nQueens; i++){
        for(int j = i + 1; j < nQueens; j++){
            if(queens[i].row == queens[j].row || queens[i].column == queens[j].column){
                valid = false;
                break;
            }
            for(int r = queens[i].row, c = queens[i].column; r < nRows && c < nColumns; r++, c++){
                if(queens[j].row == r && queens[j].column == c){
                    valid = false;
                    break;
                }
            }
            for(int r = queens[i].row, c = queens[i].column; r > 0 && c > 0; r--, c--){
                if(queens[j].row == r && queens[j].column == c){
                    valid = false;
                    break;
                }
            }
            for(int r = queens[i].row, c = queens[i].column; r < nRows && c > 0; r++, c--){
                if(queens[j].row == r && queens[j].column == c){
                    valid = false;
                    break;
                }
            }
            for(int r = queens[i].row, c = queens[i].column; r > 0 && c < nColumns; r--, c++){
                if(queens[j].row == r && queens[j].column == c){
                    valid = false;
                    break;
                }
            }
        }
    }

    if(valid){
        printf("%s\n", "valid");
    } else {
        printf("%s\n", "invalid");
    }
    return (EXIT_SUCCESS);
}

