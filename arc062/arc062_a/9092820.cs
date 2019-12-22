// detail: https://atcoder.jp/contests/arc062/submissions/9092820
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long a = 0;
        long b = 0;
        { 
            var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            a = ab[0];
            b = ab[1];
        }
        for (int i = 1; i < n; i++)
        {
            var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var newa = ab[0];
            var newb = ab[1];
            var mul = Max((a + newa - 1) / newa, (b + newb - 1) / newb);
            a = newa * mul;
            b = newb * mul;
        }
        Console.WriteLine(a + b);
    }
}
