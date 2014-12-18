using System;
using System.Collections.Generic;
using System.Numerics;
using Kattis.IO;

public class Program
{
	static double cross(Complex a, Complex b){
		return a.Real * b.Imaginary - a.Imaginary * b.Real;
	}

	static double getArea(Complex[] p){
		return Math.Abs(cross(p[1] - p[0], p[2] - p[0]) / 2);
	}

	static double polygon_area(Complex[] p, Complex s) {
		double area = 0;

		area += Math.Abs(cross(p[0] - s, p[1] - s) / 2);
		area += Math.Abs(cross(p[1] - s, p[2] - s) / 2);
		area += Math.Abs(cross(p[2] - s, p[0] - s) / 2);

		return area;
	}
	/*
	static double polygon_area(Complex[] p, Complex s) {
		return Math.Abs(polygon_area_signed(p, s));
	}*/

    static public void Main ()
    {
        Scanner scanner = new Scanner();
        BufferedStdoutWriter writer = new BufferedStdoutWriter();
        Complex[] land = new Complex[3];
        
        land[0] = new Complex(scanner.NextInt(), scanner.NextInt());
    	land[1] = new Complex(scanner.NextInt(), scanner.NextInt());
		land[2] = new Complex(scanner.NextInt(), scanner.NextInt());
        
		double landArea = getArea(land);

		int n = scanner.NextInt();
		int trees = 0;
		while(n-- > 0){
			Complex t = new Complex(scanner.NextInt(), scanner.NextInt());
			if( landArea > polygon_area(land , t) - 10E-09) {
				trees++;
			}
		}

		writer.WriteLine(landArea.ToString("F1", new System.Globalization.CultureInfo("en-US")));
		writer.WriteLine(trees);

        writer.Flush();
    }
}