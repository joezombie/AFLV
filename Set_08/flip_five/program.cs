using System;
using System.Collections.Generic;
using Kattis.IO;

public class Program
{
    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        
        bool[][] board = new bool[10][];
        for(int i = 0; i < 11; i++){
        	board[i] = new bool[10];
        }

        writer.WriteLine("Program");
        
        writer.Flush();
    }
}