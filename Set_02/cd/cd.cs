using System;
using System.Collections.Generic;
using Kattis.IO;
 
public class CD
{
    static public void Main ()
    {
    	Scanner scanner = new Scanner();
    	BufferedStdoutWriter writer = new BufferedStdoutWriter();
    	while(true){
	    	int nJack, nJill;
	    	int both = 0;
	    	nJack = scanner.NextInt();
	    	nJill = scanner.NextInt();

	    	if(nJack == 0 && nJill == 0){
	    		break;
	    	}

	    	HashSet<int> set = new HashSet<int>();

	    	for(int i = 0; i < nJack; i++){
	    		set.Add(scanner.NextInt());
	    	}

	    	for (int i = 0; i < nJill; i++){
	    		if(set.Contains(scanner.NextInt())){
	    			both += 1;
	    		}
	    	}
	    	string s = both.ToString() + "\n";
	        writer.Write(s, 0, s.Length);
	    }
	    writer.Flush();
    }
}