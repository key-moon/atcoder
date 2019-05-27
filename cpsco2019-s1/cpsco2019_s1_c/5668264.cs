// detail: https://atcoder.jp/contests/cpsco2019-s1/submissions/5668264
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<long>[] masks = Enumerable.Repeat(0, nk[1] + 1).Select(_ => new List<long>()).ToArray();
        masks[0].Add(0);
        for (int i = 0; i < nk[0]; i++)
        {
            for (int j = nk[1] - 1; j >= 0; j--)
            {
                masks[j + 1].AddRange(masks[j].Select(x => x | (1L << i)));
            }
        }
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long res = long.MaxValue;
        foreach (var mask in masks.Last())
        {
            long sum = 0;
            for (int i = 0; i < nk[0]; i++) if (((mask >> i) & 1) == 1) sum += a[i];
            var coin = sum.ToString().Select(x => x - '0').Sum(x => (x >= 5 ? 1 : 0) + x % 5);
            res = Min(res, coin);
        }
        Console.WriteLine(res);
    }
}
