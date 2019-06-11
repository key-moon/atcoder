// detail: https://atcoder.jp/contests/xmascon16noon/submissions/5875934
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
        int n = int.Parse(Console.ReadLine());
        long sum = 0;
        for (int i = 1; n != 0; i <<= 1)
        {
            if ((n & i) == 0) continue;
            sum += Query(n - i, n);
            n -= i;
        }
        Console.WriteLine($"! {sum}");
    }
    static long Query(int l, int r)
    {
        Console.WriteLine($"? {l} {r}");
        return int.Parse(Console.ReadLine());
    }
}
