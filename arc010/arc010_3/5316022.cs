// detail: https://atcoder.jp/contests/arc010/submissions/5316022
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
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var nmYZ = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nmYZ[0];
        var m = nmYZ[1];
        var Y = nmYZ[2];
        var Z = nmYZ[3];
        Dictionary<char, int> charToId = new Dictionary<char, int>();
        int[] bonus = new int[m];
        for (int i = 0; i < m; i++)
        {
            var cp = Console.ReadLine().Split();
            var c = cp[0].First();
            var p = int.Parse(cp[1]);
            charToId.Add(c, i);
            bonus[charToId[c]] = p;
        }
        var dp = new int[1 << m, m + 1];
        for (int i = 0; i < 1 << m; i++)
            for (int j = 0; j <= m; j++)
                dp[i, j] = int.MinValue / 2;
         
        dp[0, m] = 0;
        foreach (var item in Console.ReadLine())
        {
            int[,] newDP = new int[1 << m, m + 1];
            for (int i = 0; i < 1 << m; i++)
                for (int j = 0; j <= m; j++)
                    newDP[i, j] = dp[i, j];
            
            var id = charToId[item];
            for (int i = 0; i < 1 << m; i++)
            {
                for (int j = 0; j <= m; j++) newDP[i | (1 << id), id] =
                        Max(
                            newDP[i | (1 << id), id],
                            dp[i, j] + bonus[id] + (j == id ? Y : 0) + ((i & (1 << id)) == 0 && (i | (1 << id)) == ((1 << m) - 1) ? Z : 0)
                        );
            }
            dp = newDP;
        }
        var res = 0;
        for (int i = 0; i < 1 << m; i++)
            for (int j = 0; j < m; j++)
                res = Max(dp[i, j], res);
        Console.WriteLine(res);
    }
}
