// detail: https://atcoder.jp/contests/abc152/submissions/9617910
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
        int n = int.Parse(Console.ReadLine());
        long[][] masks = Enumerable.Repeat(0, n).Select(_ => new long[n]).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            masks[st[0]][st[1]] = 1L << i;
            masks[st[1]][st[0]] = 1L << i;
        }

        bool updated = true;
        while (updated)
        {
            updated = false;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n; k++)
                        if (j != k && masks[j][k] == 0 && masks[j][i] != 0 && masks[i][k] != 0)
                        {
                            masks[j][k] = masks[j][i] ^ masks[i][k];
                            updated = true;
                        }
        }

        int m = int.Parse(Console.ReadLine());
        var restrictions = Enumerable.Repeat(0, m).Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray()).ToArray();
        //制約を満たさないものの数を数える
        long res = 0;
        for (int i = 0; i < (1 << m); i++)
        {
            long bit = 0;
            int popcnt = 0;
            for (int j = 0; j < m; j++)
                if ((i >> j & 1) == 1)
                {
                    bit |= masks[restrictions[j][0]][restrictions[j][1]];
                    popcnt++;
                }
            var strictedEdge = PopCount(bit);
            var unstrictedEdge = (n - 1) - strictedEdge;
            res += ((popcnt & 1) != 0 ? -1 : 1) * (1L << unstrictedEdge);
        }
        Console.WriteLine(res);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int PopCount(long n)
    {
        int res = 0;
        for (int i = 0; i < 64; i++)
            if ((n >> i & 1) == 1) res++;
        return res;
    }
}
