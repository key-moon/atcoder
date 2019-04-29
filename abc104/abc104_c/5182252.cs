// detail: https://atcoder.jp/contests/abc104/submissions/5182252
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var dg = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var d = dg[0];
        var g = dg[1];
        var pc = Enumerable.Repeat(0, d).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int res = int.MaxValue;
        for (int i = 0; i < (1 << d); i++)
        {
            int remain = g;
            int count = 0;
            int max = -1;
            for (int j = 0; j < d; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    remain -= (j + 1) * pc[j][0] * 100 + pc[j][1];
                    count += pc[j][0];
                }
                else max = j;
            }
            if (max == -1)
            {
                if (remain <= 0) res = Min(res, count);
                continue;
            }
            if (remain > ((max + 1) * 100) * pc[max][0]) continue;
            count += (int)Ceiling((double)Max(0, remain) / ((max + 1) * 100));
            res = Min(res, count);
        }
        Console.WriteLine(res);
    }
}
