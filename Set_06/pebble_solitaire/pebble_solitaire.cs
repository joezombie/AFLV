using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Kattis.IO;

public class PebbleSolitaire
{
	const int nPebbles = 23;
	static int[] masks;
	static Dictionary<BitVector32, int> boards = new Dictionary<BitVector32, int>();

	static void generateMasks(){
		masks = new int[nPebbles];

        for(int i = 0; i < nPebbles; i++){
        	if(i == 0){
        		masks[i] = BitVector32.CreateMask();
        	}else {
        		masks[i] = BitVector32.CreateMask(masks[i-1]);
        	}
        }
	}



	static int minPebbles(BitVector32 pebbles){
		if(pebbles.Data == 0){
			boards.Add(pebbles, 0);
			return 0;
		}
		if(boards.ContainsKey(pebbles)){
			return boards[pebbles];
		}

    	int count = 0;

    	for(int i = 0; i < nPebbles; i++){
			if(pebbles[masks[i]]){
				count += 1;
			}
		}

		for(int i = 0; i < nPebbles - 1; i++){
			if(pebbles[masks[i]] && pebbles[masks[i + 1]]){
				//Jump over next pebble
				if(i < nPebbles - 2 && !pebbles[masks[i + 2]]){
					BitVector32 m1 = new BitVector32(pebbles);
					m1[masks[i]] = false;
					m1[masks[i + 1]] = false;
					m1[masks[i + 2]] = true;
					count = Math.Min(count, minPebbles(m1));
				}

				//Next pebble jumps over this one
				if(i > 0 && !pebbles[masks[i - 1]]){
					BitVector32 m2 = new BitVector32(pebbles);
					m2[masks[i + 1]] = false;
					m2[masks[i]] = false;
					m2[masks[i - 1]] = true;
					count = Math.Min(count, minPebbles(m2));
				}
			}
		}
		boards.Add(pebbles, count);
		return count;
	}

    static void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        
        int nGames = scanner.NextInt();

        BitVector32 pebbles = new BitVector32();
        generateMasks();

        while(nGames-- > 0){
        	string line = scanner.Next();

        	for(int i = 0; i < nPebbles; i++){
        		pebbles[masks[i]] = (line[i] == 'o');
        	}

        	int min = minPebbles(pebbles);

	        string s = min.ToString() + "\n";
        	writer.Write(s, 0, s.Length);
        }
        
        writer.Flush();
    }
}