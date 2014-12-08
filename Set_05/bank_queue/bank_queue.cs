using System;
using System.Collections.Generic;
using Kattis.IO;

public class Person{
    public int cash;
    public int minutes;

    public Person(int cash, int minutes){
        this.cash = cash;
        this.minutes = minutes;
    }

    public override String ToString(){
        return "Cash:" + cash.ToString() 
             + " Minutes:" + minutes.ToString();
    }
}

public class SortByCash: IComparer<Person>{
    public int Compare(Person a, Person b){
        if(a.cash == b.cash){
            return 0;
        } else if( a.cash < b.cash){
            return 1;
        } else {
            return -1;
        }
    }
}

public class SortByMinutes: IComparer<Person>{
    public int Compare(Person a, Person b){
        if(a.minutes == b.minutes){
            return 0;
        } else if( a.minutes < b.minutes){
            return 1;
        } else {
            return -1;
        }
    }
}

public class BankQueue
{
    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        
        int nPeople = scanner.NextInt();
        int nMinutes = scanner.NextInt();

        List<Person> queue = new List<Person>();

        for(int i = 0; i < nPeople; i++){
           queue.Add(new Person( scanner.NextInt(), scanner.NextInt() ));
        }

        SortByCash SortByCash = new SortByCash();
        SortByMinutes sortByMinutes = new SortByMinutes();
        
        queue.Sort(sortByMinutes);        

        int maxCash = 0;
        int count = 0;
        for(int i = nMinutes - 1; i >= 0 ; i--){
            for(int j = count; j < queue.Count; j++){
                if(queue[j].minutes < i){
                    break;
                } else {
                    count += 1;
                }
            }
            
            if(count > 0){
                queue.Sort(0, count, SortByCash);
                maxCash += queue[0].cash;
                queue[0].cash = 0;
                queue.Sort(sortByMinutes);
            }
        }
        
        string s = maxCash.ToString() + "\n";
        writer.Write(s, 0, s.Length);
        
        writer.Flush();
    }
}