using System;
using System.Text;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kattis.IO;

public class Orders
{
	static int nItems;
	static int[] menuItems;
	static Dictionary<int, order> orders = new Dictionary<int, order>();

	public struct order{
		public string items;
		public bool ambigous;
		public bool complete;

		public order(string items){
			this.items = items;
			ambigous = false;
			complete = false;
		}

		override public string ToString(){
			if(complete){
				if(ambigous){
					return "Ambiguous";
				} else {
					return items;
				}
			} else {
				return "Impossible";
			}
		}
	}

	int[][] mem;

	static public order findOrder(int cost){
		if(orders.ContainsKey(cost)){
			return orders[cost];
		}

		return findOrder(0, 0, cost);
	}

	static public order findOrder(int i, int cost){
		order result = new order(null);

		return result;
	}

    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        
		nItems = scanner.NextInt();
		menuItems = new int[nItems];
		mem = new int[n]

		for(int i = 0; i < nItems; i++){
			menuItems[i] = scanner.NextInt();
		}

		Array.Sort(menuItems);

		foreach (int i in menuItems) {
			Console.WriteLine(i);
		}


		int nOrders = scanner.NextInt();

		for(int i = 0; i < nOrders; i++){
			//order iOrder = findOrder(scanner.NextInt());
			//string s = iOrder.ToString() + "\n";
			//writer.Write(s, 0, s.Length);
		}
        
        writer.Flush();
    }
}