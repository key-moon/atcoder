// detail: https://atcoder.jp/contests/joisc2007/submissions/6050372
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var map = Enumerable.Repeat(0, nm[1]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var accum = Enumerable.Repeat(0, nm[1] + 1).Select(_ => new long[nm[0] + 1]).ToArray();
        for (int i = 0; i < nm[1]; i++)
        {
            long currentAccum = 0;
            for (int j = 0; j < nm[0]; j++)
            {
                currentAccum += map[i][j] < 0 ? int.MaxValue : map[i][j];
                accum[i + 1][j + 1] = accum[i][j + 1] + currentAccum;
            }
        }
        var min = long.MaxValue;
        for (int i = ab[1]; i <= nm[1]; i++)
        {
            for (int j = ab[0]; j <= nm[0]; j++)
            {
                min = Min(min, accum[i][j] - accum[i - ab[1]][j] - accum[i][j - ab[0]] + accum[i - ab[1]][j - ab[0]]);
            }
        }
        Console.WriteLine(min);
    }
}
