// detail: https://atcoder.jp/contests/agc041/submissions/9177117
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
        var nab = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nab[0];
        var a = nab[1];
        var b = nab[2];
        var diff = Abs(a - b);
        if (diff % 2 == 0)
        {
            Console.WriteLine(diff / 2);
            return;
        }
        Console.WriteLine(Min(Solve(a - 1, b - 1), Solve(n - a, n - b)));
    }
    static long Solve(long a, long b)
    {
        if (a > b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
        var min = a;
        a -= min;
        b -= min;
        b -= 1;
        return min + 1 + b / 2;
    }
}
