// detail: https://atcoder.jp/contests/tenka1-2017/submissions/5035297
using System;
using System.IO;
using System.Linq;
using System.Collections;
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
        long ln = long.Parse(Console.ReadLine());
        double n = (double)ln;
        for (int i = 1; i <= 3500; i++)
        {
            for (int j = 1; j <= 3500; j++)
            {
                var k = 1 / (4 / n - (1.0 / i + 1.0 / j));
                var floor = (int)Floor(k);
                var ceil = (int)Ceiling(k);

                if (floor > 0 && Judge(ln, i, j, floor))
                {
                    Console.WriteLine($"{i} {j} {floor}");
                    return;
                }
                if (ceil > 0 && Judge(ln, i, j, ceil))
                {
                    Console.WriteLine($"{i} {j} {ceil}");
                    return;
                }
            }
        }
    }
    static bool Judge(long N, long h, long n, long w) => 4 * h * n * w == N * (h * n + n * w + w * h);
}
