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
        	int n = scanner.NextInt();

        	int j = 1;
        	int cnt = 1;
        	while(j % n > 0){
       			cnt += 1;
        		j = ((j % n) * (10 % n)) + 1;
        	}
        	writer.WriteLine(cnt);
        }
        
        writer.Flush();
    }
}