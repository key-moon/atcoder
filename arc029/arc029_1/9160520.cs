// detail: https://atcoder.jp/contests/arc029/submissions/9160520
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
        var t = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        var res = int.MaxValue;
        for (int i = 0; i < (1 << n); i++)
        {
            var a = new int[2];
            for (int j = 0; j < n; j++)
            {
                a[(1 & (i >> j))] += t[j];
            }
            res = Min(res, a.Max());
        }
        Console.WriteLine(res);
    }
}
