// detail: https://atcoder.jp/contests/abc005/submissions/8331025
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var accums = Enumerable.Repeat(0, n + 1).Select(_ => new int[n + 1]).ToArray();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                accums[i + 1][j + 1] = a[i][j] + accums[i][j + 1] + accums[i + 1][j] - accums[i][j];
            }
        }

        int[] res = new int[n * n + 1];
        for (int h = 1; h <= n; h++)
        {
            for (int w = 1; w <= n; w++)
            {
                var max = 0;
                for (int y = h; y <= n; y++)
                    for (int x = w; x <= n; x++)
                        max = Max(max, accums[y][x] - accums[y - h][x] - accums[y][x - w] + accums[y - h][x - w]);
                res[h * w] = Max(res[h * w], max);
            }
        }

        for (int i = 1; i < res.Length; i++)
            res[i] = Max(res[i], res[i - 1]);

        int q = int.Parse(Console.ReadLine());
        for (int i = 0; i < q; i++)
        {
            var p = int.Parse(Console.ReadLine());
            Console.WriteLine(res[p]);
        }
    }
}
 
