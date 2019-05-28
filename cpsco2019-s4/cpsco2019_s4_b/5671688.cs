// detail: https://atcoder.jp/contests/cpsco2019-s4/submissions/5671688
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
        var nd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var d = Enumerable.Repeat(0, nd[1]).Select(_ => Console.ReadLine()).ToArray();
        var max = 0;
        for (int i = 0; i < nd[1] - 1; i++)
        {
            for (int j = i + 1; j < nd[1]; j++)
            {
                max = Max(max, d[i].Zip(d[j], (x, y) => x == 'o' || y == 'o' ? 1 : 0).Sum());
            }
        }
        Console.WriteLine(max);
    }
}
