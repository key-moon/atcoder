// detail: https://atcoder.jp/contests/jsc2019-qual/submissions/7116482
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        memo[1] = new int[][] { new int[] { 1 } };
        int n = int.Parse(Console.ReadLine());
        Console.Write(string.Join("
", Solve(n).Select((x, y) => string.Join(" ", x.Skip(y + 1)))));
    }

    static int[][][] memo = new int[501][][];

    static int[][] Solve(int n)
    {
        if (memo[n] != null) return memo[n];
        if (n % 2 == 1) return memo[n] = Solve(n + 1).Take(n).Select(x => x.Take(n).ToArray()).ToArray();
        int[][] res = Enumerable.Repeat(0, n).Select(_ => new int[n]).ToArray();
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j += 2)
            {
                res[i][j] = 1;
                res[j][i] = 1;
            }
        }
        var inner = Solve(n / 2);
        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j < n / 2; j++)
            {
                res[i * 2][j * 2] = inner[i][j] + 1;
                res[i * 2 + 1][j * 2 + 1] = inner[i][j] + 1;
            }
        }
        return memo[n] = res;
    }
}
