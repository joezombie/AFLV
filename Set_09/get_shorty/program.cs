using System;
using System.Collections.Generic;
using Kattis.IO;

public class Program
{
    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        
        while(scanner.HasNext()){
        	int nIntersections = scanner.NextInt();
        	int nCorridors = scanner.NextInt();

        	for(int i = 0; i < nCorridors; i++){
        		int x = scanner.NextInt();
        		int y = scanner.NextInt();
        		float f = float.Parse(scanner.Next());

        		writer.WriteLine(x);
        		writer.WriteLine(y);
        		Console.WriteLine(f);
        		writer.WriteLine();
        	}
        }
        
        writer.Flush();
    }
}