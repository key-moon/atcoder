// detail: https://atcoder.jp/contests/abc151/submissions/9470262
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
public static class P
{
    public static void Main()
    {
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hw[0];
        var w = hw[1];
        var map = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine().Select(x => x == '.').ToArray()).ToArray();
        int[][] cost = Enumerable.Range(0, h * w).Select(_ => Enumerable.Repeat(13333, h * w).ToArray()).ToArray();
        for (int i = 0; i < h * w; i++)
            cost[i][i] = 0;
        for (int i = 0; i < h - 1; i++)
            for (int j = 0; j < w; j++)
            { var id = i * w + j; if (map[i][j] && map[i + 1][j]) cost[id][id + w] = (cost[id + w][id] = 1); }
        for (int i = 0; i < h; i++)
            for (int j = 0; j < w - 1; j++)
            { var id = i * w + j; if (map[i][j] && map[i][j + 1]) cost[id][id + 1] = (cost[id + 1][id] = 1); }
        for (int i = 0; i < cost.Length; i++)
            for (int j = 0; j < cost.Length; j++)
                for (int k = 0; k < cost.Length; k++)
                    cost[j][k] = Min(cost[j][k], cost[j][i] + cost[i][k]);
        Console.WriteLine(cost.Max(x => x.Max(y => 13333 == y ? -1 : y)));
    }
}
