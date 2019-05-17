// detail: https://atcoder.jp/contests/arc064/submissions/5425263
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;


static class P
{
    static void Main()
    {
        var Nx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = Nx[0];
        var x = Nx[1];
        var a = Enumerable.Repeat(0, 1).Concat(Console.ReadLine().Split().Select(int.Parse)).ToArray();
        long res = 0;
        for (int i = 1; i < a.Length; i++)
        {
            var op = Max(0, a[i - 1] + a[i] - x);
            a[i] -= op;
            res += op;
        }
        Console.WriteLine(res);
    }
}
