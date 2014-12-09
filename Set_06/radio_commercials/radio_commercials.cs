using System;
using System.Collections.Generic;
using Kattis.IO;

public class Problem
{
    static public int[] arr;
    static public int[] mem;
    static public bool[] comp;

    static public int max_sum(int i) {
        if (i == 0) {
            return arr[i];
        }
        if (comp[i]) {
            return mem[i];
        }
        int res = Math.Max(arr[i], arr[i] + max_sum(i - 1));
        mem[i] = res;
        comp[i] = true;
        return res;
    }

    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
                
        int nBreaks = scanner.NextInt();
        int breakCost = scanner.NextInt();
        arr = new int[nBreaks];
        mem = new int[nBreaks];
        comp = new bool[nBreaks];

        for(int i = 0; i < nBreaks; i++){
            arr[i] = scanner.NextInt() - breakCost;
        }

        int max = 0;

        for(int i = 0; i < nBreaks; i++){
            max = Math.Max(max, max_sum(i));
        }

        string s = max.ToString() + "\n";
        
        writer.Write(s, 0, s.Length);
        writer.Flush();
    }
}