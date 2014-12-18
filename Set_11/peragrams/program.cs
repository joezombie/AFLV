using System;
using System.Collections.Generic;
using Kattis.IO;

public class Program
{
	const int nChars = 'z' - 'a' + 1;
    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        

        int[] chars = new int[nChars];

        string s = scanner.Next();

        for(int i = 0; i < s.Length; i++){
        	chars[s[i] - 'a']++;
        }

        int ans = 0;
        for(int i = 0; i < nChars; i++){
        	ans += chars[i] % 2;
        }

        writer.WriteLine(Math.Max(0, ans - 1));
        
        writer.Flush();
    }
}