// detail: https://atcoder.jp/contests/abc011/submissions/5491475
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
        int n = int.Parse(Console.ReadLine());
        int[] step = Enumerable.Repeat(int.MaxValue / 2, n + 4).ToArray();
        int[] ng = Enumerable.Repeat(0, 3).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        if (!ng.Contains(n)) step[n] = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (ng.Contains(i)) continue;
            step[i] = Min(step[i + 1], Min(step[i + 2], step[i + 3])) + 1;
        }
        Console.WriteLine(step[0] <= 100 ? "YES" : "NO");
    }
}
