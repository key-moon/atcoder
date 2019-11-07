// detail: https://atcoder.jp/contests/abc056/submissions/8329756
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
    static int k;
    public static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        k = nk[1];
        var a = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();

        var valid = -1;
        var invalid = a.Length;
        while (invalid - valid > 1)
        {
            var mid = (valid + invalid) / 2;
            if (IsValid(a, mid)) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine(invalid);
    }

    static bool IsValid(int[] a, int targetInd)
    {
        bool[] canAchive = new bool[k];
        canAchive[0] = true;
        foreach (var item in a.Where((_, ind) => ind != targetInd))
        {
            for (int i = canAchive.Length - item - 1; i >= 0; i--)
            {
                if (canAchive[i]) canAchive[i + item] = true;
            }
        }
        if (canAchive.Skip(k - a[targetInd]).Any(x => x)) return false;
        return true;
    }
}
