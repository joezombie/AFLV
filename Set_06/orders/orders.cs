using System;
using System.Text;
using System.Collections.Generic;
using Kattis.IO;

public class Orders
{
	static int nItems;
	static int[] menuItems;
	static Dictionary<int, order> orders = new Dictionary<int, order>();

	public struct order{
		public List<int> items;
		public bool ambigous;
		public bool complete;

		public order(List<int> items){
			this.items = items;
			ambigous = false;
			complete = false;
		}

		override public string ToString(){
			if(complete){
				if(ambigous){
					return "Ambiguous";
				} else {
					StringBuilder sb = new StringBuilder();
					foreach(int i in items){
						sb.Append(i.ToString());
						sb.Append(" ");
					}
					return sb.ToString();
				}
			} else {
				return "Impossible";
			}
		}
	}

	static public order findOrder(int cost){
		if(orders.ContainsKey(cost)){
			return orders[cost];
		}

		return findOrder(new List<int>(), 0, cost);
	}

	static public order findOrder(List<int> items, int sum, int cost){
		order result = new order(items);

		// -- Remove
		Console.WriteLine("-- " + cost.ToString() + " " + sum.ToString() + " --");
		foreach(int i in items){
			Console.Write(i.ToString() + " ");
		}
		Console.WriteLine("\n---");
		// --

		for(int i = 0; i < nItems; i++){
			int newSum = sum + menuItems[i];
			
			if(newSum == cost){
				items.Add(menuItems[i]);
				result = order(items);
				result.complete = true;
				if(orders.ContainsKey(cost)){
					// Does not work
					/*
					if(orders[cost].items.Equals(newOrder.items)){
						Console.WriteLine("equals");
					} else {
						Console.WriteLine("does not equal");
						result.ambigous = true;
					}*/
				} else {
					
				}
			}
			if(newSum < cost){
				items.Add(menuItems[i]);
				order newOrder = findOrder(new List<int>(items), newSum, cost);
				if(newOrder.complete){
					result = newOrder;
					if(orders.ContainsKey(cost)){
						result.ambigous = true;	
					}else {
						orders.Add(cost, newOrder);
					}
				}
			}
		}

		return result;
	}

    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        
		nItems = scanner.NextInt();
		menuItems = new int[nItems];

		for(int i = 0; i < nItems; i++){
			menuItems[i] = scanner.NextInt();
		}

		int nOrders = scanner.NextInt();

		for(int i = 0; i < nOrders; i++){
			order iOrder = findOrder(scanner.NextInt());
			string s = iOrder.ToString() + "\n";
			writer.Write(s, 0, s.Length);
		}
        
        writer.Flush();
    }
}