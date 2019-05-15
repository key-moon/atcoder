// detail: https://atcoder.jp/contests/abc112/submissions/5411389
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var ub = m / n;
        int max = 1;
        var sqrtm = (int)Ceiling(Sqrt(m));
        for (int i = 1; i <= sqrtm; i++)
        {
            if (m % i != 0) continue;
            if (i <= ub) max = Max(max, i);
            if (m / i <= ub) max = Max(max, m / i);
        }
        Console.WriteLine(max);
    }
}
