// detail: https://atcoder.jp/contests/abc109/submissions/6371243
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var map = Enumerable.Repeat(0, hw[0]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        List<Tuple<Tuple<int, int>, Tuple<int, int>>> ops = new List<Tuple<Tuple<int, int>, Tuple<int, int>>>();
        for (int i = 0; i < hw[0]; i++)
        {
            for (int j = 0; j < hw[1] - 1; j++)
            {
                if (map[i][j] % 2 == 1)
                {
                    map[i][j]--;
                    map[i][j + 1]++;
                    ops.Add(new Tuple<Tuple<int, int>, Tuple<int, int>>(new Tuple<int, int>(i + 1, j + 1), new Tuple<int, int>(i + 1, j + 2)));
                }
            }
        }
        for (int i = 0; i < hw[0] - 1; i++)
        {
            int j = hw[1] - 1;
            if (map[i][j] % 2 == 1)
            {
                map[i][j]--;
                map[i + 1][j]++;
                ops.Add(new Tuple<Tuple<int, int>, Tuple<int, int>>(new Tuple<int, int>(i + 1, j + 1), new Tuple<int, int>(i + 2, j + 1)));
            }
        }
        Console.WriteLine(ops.Count);
        Console.WriteLine(string.Join("
", ops.Select(x => $"{x.Item1.Item1} {x.Item1.Item2} {x.Item2.Item1} {x.Item2.Item2}")));
    }
}
