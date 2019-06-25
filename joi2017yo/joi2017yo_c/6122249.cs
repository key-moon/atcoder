// detail: https://atcoder.jp/contests/joi2017yo/submissions/6122249
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
        var nmd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = nmd[0], m = nmd[1], d = nmd[2];
        int res = 0;
        int[] columnChain = new int[m];
        var map = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).ToArray();
        for (int i = 0; i < n; i++)
        {
            int currentChain = 0;
            for (int j = 0; j < m; j++)
            {
                if (map[i][j] == '#')
                {
                    res += Max(0, currentChain - d + 1);
                    res += Max(0, columnChain[j] - d + 1);
                    currentChain = 0;
                    columnChain[j] = 0;
                }
                else
                {
                    currentChain++;
                    columnChain[j]++;
                }
            }
            res += Max(0, currentChain - d + 1);
        }
        for (int i = 0; i < m; i++)
        {
            res += Max(0, columnChain[i] - d + 1);
        }
        Console.WriteLine(res);
    }
}
