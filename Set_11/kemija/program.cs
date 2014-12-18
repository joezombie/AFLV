using System;
using System.Collections.Generic;
using Kattis.IO;

public class Program
{
    static readonly string[] code = {"apa", "epe", "ipi", "opo", "upu"};

    static string decode(string s){
        for(int i = 0; i < code.Length; i++){
            s = s.Replace(code[i], (string)code[i].Substring(0, 1));
        }
        return s;
    }

    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        
        while(scanner.HasNext()){
        	writer.Write(decode(scanner.Next()));
            writer.Write(" ");
        }
        writer.Write("\n");
        
        writer.Flush();
    }
}