// detail: https://atcoder.jp/contests/abc007/submissions/8331448
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var ab = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var startCount = Solve(ab[1]);
        var endCount = Solve(ab[0] - 1);
        Console.WriteLine(startCount - endCount);
    }

    static long Solve(long a)
    {
        int[] lessCount = { 0, 1, 2, 3, 4, 4, 5, 6, 7, 8 };
        long freeCount = 0;
        long bindCount = 1;
        foreach (var c in a.ToString())
        {
            freeCount *= 10 - 2;
            freeCount += bindCount * lessCount[c - '0'];
            if (c == '4' || c == '9') bindCount = 0;
        }
        return (a + 1) - (freeCount + bindCount);
    }
}
 
