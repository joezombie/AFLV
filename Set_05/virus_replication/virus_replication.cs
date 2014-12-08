using System;
using System.Collections.Generic;
using Kattis.IO;
 
public class PlantingTrees
{
    static public void Main ()
    {
    	Scanner scanner = new Scanner();
    	BufferedStdoutWriter writer = new BufferedStdoutWriter();
    	
        string a = scanner.Next();
        string b = scanner.Next();

        int start = 0;
        int end = 0;

        for (int i = 0; i < a.Length && i < b.Length; i++){
            if(a[i] != b[i]){
                start = i;
                break;
            }
        }

        for (int i = 0; i < a.Length && i < b.Length; i++){
            if(a[a.Length-i-1] != b[b.Length-i-1]){
                end = b.Length - i;
                break;
            }
        }


        int changes = Math.Max(Math.Max(end - start, 0), b.Length - a.Length);
        
        string s = changes.ToString() + "\n";
        writer.Write(s, 0, s.Length);
        
	    
	    writer.Flush();
    }
}