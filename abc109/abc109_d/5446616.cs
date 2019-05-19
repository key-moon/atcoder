// detail: https://atcoder.jp/contests/abc109/submissions/5446616
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
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Enumerable.Repeat(0, hw[0]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        List<int[]> ops = new List<int[]>();
        for (int i = 0; i < hw[0]; i++)
        {
            for (int j = 0; j < hw[1] - 1; j++)
            {
                if (a[i][j] % 2 == 1)
                {
                    ops.Add(new int[] { i + 1, j + 1, i + 1, j + 2 });
                    a[i][j]--;
                    a[i][j + 1]++;
                }
            }
            if (i != hw[0] - 1 && a[i][hw[1] - 1] % 2 == 1)
            {
                ops.Add(new int[] { i + 1, hw[1], i + 2, hw[1] });
                a[i][hw[1] - 1]--;
                a[i + 1][hw[1] - 1]++;
            }
        }
        Console.WriteLine(ops.Count);
        Console.WriteLine(string.Join("
", ops.Select(x => string.Join(" ", x))));
    }
}
