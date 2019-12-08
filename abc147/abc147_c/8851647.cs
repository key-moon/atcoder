// detail: https://atcoder.jp/contests/abc147/submissions/8851647
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

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] conf = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            int a = int.Parse(Console.ReadLine());
            for (int j = 0; j < a; j++)
            {
                var xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
                conf[i, xy[0] - 1] = xy[1] == 1 ? 1 : -1;
            }
        }
        int max = 0;
        for (int state = 0; state < (1 << n); state++)
        {
            bool[] isGood = Enumerable.Range(0, n).Select(x => (state & (1 << x)) != 0).ToArray();
            for (int i = 0; i < n; i++)
            {
                if (!isGood[i]) continue;
                for (int j = 0; j < n; j++)
                {
                    if (conf[i, j] == 0) continue;
                    if ((conf[i, j] == 1) == isGood[j]) continue;
                    goto end;
                }
            }
            max = Max(max, isGood.Count(x => x));
        end:;
        }
        Console.WriteLine(max);
    }
}
