// detail: https://atcoder.jp/contests/abc144/submissions/8167450
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var nk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        //にんげん
        var a = Console.ReadLine().Split().Select(long.Parse).OrderByDescending(x => x).ToArray();
        //ごはん
        var f = Console.ReadLine().Split().Select(long.Parse).OrderBy(x => x).ToArray();

        var valid = long.MaxValue / 2; ;
        long invalid = -1;
        while (valid - invalid > 1)
        {
            var mid = (valid + invalid) / 2;
            if (Achivable(k, mid, a, f)) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine(valid);
    }

    static bool Achivable(long k, long score, long[] a, long[] f) => a.Zip(f, (x, y) => Max(0, (x * y - score + y - 1) / y)).Sum() <= k;    
}
