// detail: https://atcoder.jp/contests/abc144/submissions/8163633
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var abx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        double a = abx[0];
        double b = abx[1];
        double x = abx[2];
        x /= a;
        //
        double res;
        if (x >= a * b / 2) res = Calc(a, (a * b - x) * 2 / a);
        else res = Calc(x * 2 / b, b);
        Console.WriteLine(res);
    }
    //    　/|
    //   　/ |
    //  　/  | b
    // θ/___|
    //   a
    public static double Calc(double a, double b) => Atan(b / a) / PI * 180;
    
}
