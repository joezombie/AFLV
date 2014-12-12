using System;
using System.Collections.Generic;
using Kattis.IO;

public class Program
{
    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        
        int caseNr = 0;
        string format = "Case {0}: {1}";

        while(scanner.HasNext()){
        	caseNr += 1;
        	int n = scanner.NextInt();
        	
        	double circ = 3;
        	double iCirc = 3;
        	for(int i = 1; i <= n; i++){
        		iCirc = iCirc/2;
        		circ += iCirc * Math.Pow(3, i);
        	}

        	int nrSize = (int)Math.Ceiling(Math.Log10(circ));

        	writer.WriteLine(String.Format(format, caseNr, nrSize));
        }
        
        writer.Flush();
    }
}