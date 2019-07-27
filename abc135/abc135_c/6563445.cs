// detail: https://atcoder.jp/contests/abc135/submissions/6563445
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
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var res = (long)0;
        for (int i = 0; i < n; i++)
        {
            var totalKill = b[i];
            var kill = Min(totalKill, a[i]);
            a[i] -= kill;
            totalKill -= kill;
            res += kill;
            kill = Min(totalKill, a[i + 1]);
            a[i + 1] -= kill;
            totalKill -= kill;
            res += kill;
        }
        Console.WriteLine(res);
    }
}
