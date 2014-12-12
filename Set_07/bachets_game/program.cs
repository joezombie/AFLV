using System;
using System.Text;
using System.Collections.Generic;
using Kattis.IO;

public class Program
{
    const int MAX_MOVES = 10;
    const int MAX_STONES = 1000000;

    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        int[] moves = new int[MAX_MOVES];

        while(scanner.HasNext()){
        	int nStones = scanner.NextInt();
        	int nMoves = scanner.NextInt();
        	bool[] stones = new bool[nStones + 1];

        	for(int i = 0; i < nMoves; i++){
        		moves[i] = scanner.NextInt();
        	}
            
            
            for(int i = nStones; i >= 0; i--){
                if(!stones[i]){
                    for(int j = 0; j < nMoves; j++){
                        int k = i - moves[j];
                        if(k >= 0){
                            stones[k] = true;
                        }
                    }
                }
            }
            
            /*
            for(int i = nStones; i >= 0; i--){
                writer.Write(i);
                writer.Write(" ");
            }
            writer.Write("\n");
            for(int i = nStones; i >= 0; i--){
                if(stones[i]){
                    writer.Write("P ");
                } else {
                    writer.Write("N ");
                }
                if(i > 9){
                    writer.Write(" ");
                }
            }
            writer.Write("\n");
            */
            
            if(stones[0]){
                writer.WriteLine("Stan wins");
            }else {
                writer.WriteLine("Ollie wins");
            }
        }

        writer.Flush();
    }
}