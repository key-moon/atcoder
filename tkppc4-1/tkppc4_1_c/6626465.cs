// detail: https://atcoder.jp/contests/tkppc4-1/submissions/6626465
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
        var nx = Console.ReadLine().Split();
        var n = long.Parse(nx[0]);
        for (int i = 2;; i++)
        {
            if (ConvertToBaseN(n, i) == nx[1])
            {
                Console.WriteLine(i);
                return;
            }
        }
    }

    static string ConvertToBaseN(long n, int b)
    {
        long[] res = new long[100];
        int index = res.Length - 1;
        while (n != 0)
        {
            res[index--] = n % b;
            n /= b;
        }
        return string.Join("", res.SkipWhile(x => x == 0));
    }
}
