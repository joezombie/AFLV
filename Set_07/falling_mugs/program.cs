using System;
using System.Collections.Generic;
using Kattis.IO;

public class Program
{
	struct frameSpan{
		public frameSpan(int n, int x){
			this.n = n;
			this.x = x;
		}

		public int n;
		public int x;
	}
    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        Dictionary<int, frameSpan> frameSpans = new Dictionary<int, frameSpan>();

        while(scanner.HasNext()){
        	int D = scanner.NextInt();
        	frameSpan n;

        	bool found = false;
        	if(frameSpans.ContainsKey(D)){
        		n = frameSpans[D];
        		found = true;
        	} else {
        		n = new frameSpan(0, 1);
        		int sqrD = (int) Math.Ceiling(Math.Sqrt(D));
        		for(; n.n < D ; n.n++){
        			for(n.x = 1; n.x <= sqrD; n.x++){
        				if(2 * n.x * n.n + (n.x * n.x) == D){
        					found = true;
        					frameSpans.Add(D, n);
        					break;
        				}
        			}
        			
        			if(found){ break; }
        		}
        	}
        	


        	if(found){
		    	writer.Write(n.n);
		    	writer.Write(" ");
		    	writer.Write(n.n + n.x);
		    	writer.Write("\n");
		    } else {
		    	writer.WriteLine("impossible");
		    }
        }
        
        writer.Flush();
    }
}