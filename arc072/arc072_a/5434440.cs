// detail: https://atcoder.jp/contests/arc072/submissions/5434440
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Min(Solve(a, 1), Solve(a, -1)));
    }
    static long Solve(int[] a, int target)
    {
        long res = 0;
        var accum = 0;
        for (int i = 0; i < a.Length; i++)
        {
            accum += a[i];
            if (accum * target <= 0)
            {
                res += Abs(target - accum);
                accum = target;
            }
            target *= -1;
        }
        return res;
    }
}
