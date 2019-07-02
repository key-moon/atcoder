// detail: https://atcoder.jp/contests/abc013/submissions/6215983
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var nh = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long n = nh[0], h = nh[1];
        var abcde = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long a = abcde[0], b = abcde[1], c = abcde[2], d = abcde[3], e = abcde[4];
        //全日食事抜き前提、食事をすると抜いた分も回復
        h -= e * n;
        b += e;
        d += e;
        long minCost = long.MaxValue;
        for (long i = 0; i <= n; i++)
        {
            long cost = a * i;
            long currentHealth = h + b * i;
            long feedCount = 0 < currentHealth ? 0 : -currentHealth / d + 1;
            cost += c * feedCount;
            minCost = Min(minCost, cost);
        }
        Console.WriteLine(minCost);
    }
}
