// detail: https://atcoder.jp/contests/abc149/submissions/9215299
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
        var nk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = (int)nk[0];
        var m = nk[1];
        var a = Console.ReadLine().Split().Select(long.Parse).OrderByDescending(x => x).ToArray();
        //一回の握手で得られる幸福度が単調減少するため、m回で得られる奴 
        var valid = 0;
        var invalid = 200001;
        while (invalid - valid > 1)
        {
            var mid = (invalid + valid) / 2;
            long ctr = 0;
            for (int i = 0; i < n; i++)
            {
                ctr += a.LargerCount(mid - a[i]);
            }
            if (m <= ctr) valid = mid;
            else invalid = mid;
        }
        long res = 0;
        var accum = new long[a.Length + 1];
        for (int i = 0; i < a.Length; i++)
            accum[i + 1] = a[i] + accum[i];
        long count = 0;
        long min = long.MaxValue;
        for (int i = 0; i < n; i++)
        {
            var largerCount = a.LargerCount(valid - a[i]);
            count += largerCount;
            if (largerCount != 0) min = Min(min, a[i] + a[largerCount - 1]);
            res += largerCount * a[i];
            res += accum[largerCount];
        }
        res -= Max(count - m, 0) * min;
        Console.WriteLine(res);
    }
    static int LargerCount(this long[] a, long threshold)
    {
        var valInd = -1;
        var invalInd = a.Length;
        while (invalInd - valInd > 1)
        {
            var midInd = (valInd + invalInd) / 2;
            if (threshold <= a[midInd]) valInd = midInd;
            else invalInd = midInd;
        }
        return valInd + 1;
    }
}
