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
	struct queen queens[8];

	const int rows = 8;
	const int columns = 8;
	bool board[rows][columns];
	memset(board, 0, rows * columns * sizeof(bool));

    for(int i=0, j=0, q=0; read(0, buf, sizeof(buf)) > 0;){
    	switch(buf[0]){
    		case '\n':
    			i++;
    			j = 0;
    			break;
    		case '*':
    			board[i][j] = true;
                queens[q].row = i;
                queens[q].column = j;
                q += 1;
			case '.':
			default:
				j++;
    	}
    }

	for(int i=0; i < rows; i++){
    	printf("%d - ", i);

    	for(int j=0; j < columns; j++){
    		printf("%d ", board[i][j]);
    	}
    	printf("\n");
    }

    for(int i = 0; i < 8; i++){
        printf("%d row:%d column:%d\n", i, queens[i].row, queens[i].column);
    }

    return (EXIT_SUCCESS);
}

