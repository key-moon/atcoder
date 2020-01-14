// detail: https://atcoder.jp/contests/abc150/submissions/9505961
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var n = nm[0];
        var m = nm[1];
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var gcd = a.Aggregate(GCD);
        var lcm = a.Aggregate(LCM);
        if (lcm / gcd % 2 == 0)
        {
            Console.WriteLine(0);
            return;
        }
        lcm /= 2;
        Console.WriteLine((m / lcm + 1) / 2);
    }

    static long GCD(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            a %= b;
            if (a == 0) return b;
            b %= a;
        }
    }

    static long LCM(long a, long b) 
    {
        var res = a / GCD(a, b) * b;
        if (int.MaxValue < res) return 0;
        return res;
    }
}
