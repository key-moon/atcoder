// detail: https://atcoder.jp/contests/agc027/submissions/5308136
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
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;

static class P
{
    static void Main()
    {
        var max = 500;
        var primes = Primes(10000).ToArray();
        var rprimes = primes.Take(max).ToArray();
        var cprimes = primes.Skip(max).ToArray();
        long[][] res = Enumerable.Repeat(0, max).Select(_ => Enumerable.Repeat(1L, max).ToArray()).ToArray();

        for (int iter = 0; iter < max; iter++)
        {
            for (int i = -max + 2 + 2 * iter, j = 0; i <= max && j < max; i++, j++)
            {
                if (0 <= i - 1 && i - 1 < max) res[i - 1][j] *= rprimes[iter];
                if (0 <= i + 1 && i + 1 < max) res[i + 1][j] *= rprimes[iter];
                if (i < 0 || max <= i) continue;
                res[i][j] *= rprimes[iter];
            }
        }

        for (int iter = 0; iter < max; iter++)
        {
            for (int i = -max + 1 + 2 * iter, j = max - 1; i <= max && j >= 0; i++, j--)
            {
                if (0 <= i - 1 && i - 1 < max) res[i - 1][j] *= cprimes[iter];
                if (0 <= i + 1 && i + 1 < max) res[i + 1][j] *= cprimes[iter];
                if (i < 0 || max <= i) continue;
                res[i][j] *= cprimes[iter];
            }
        }
        for (int iter = 0; iter < max; iter++)
        {
            for (int i = -max + 1 + 2 * iter, j = 0; i < max && j < max; i++, j++)
            {
                if (i < 0) continue;
                res[i][j]++;
            }
        }
        var n = int.Parse(Console.ReadLine());
        Console.WriteLine(string.Join("
", res.Select(x => string.Join(" ", x.Take(n))).Take(n)));
    }

    public static IEnumerable<int> Primes(int n)
    {
        if (n <= 32)
        {
            int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };
            for (int i = 0; i < primes.Length; i++)
            {
                if (n < primes[i]) break;
                else yield return primes[i];
            }
            yield break;
        }

        yield return 2;
        int sup = (n + 1) / 32 / 2 + 1;
        uint[] isp = new uint[sup];

        int[] tprimes = { 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };
        for (int i = 0; i < tprimes.Length; i++)
        {
            var tp = tprimes[i];
            yield return tp;
            uint[] ptn = new uint[tp];
            for (int j = (tp - 3) / 2; j < (tp << 5); j += tp) ptn[j >> 5] |= 1U << (j & 31);
            for (int j = 0; j < tp; j++) for (int l = j; l < sup; l += tp) isp[l] |= ptn[j];
        }

        int[] magic = { 0, 1, 23, 2, 29, 24, 19, 3, 30, 27, 25, 11, 20, 8, 4, 13, 31, 22, 28, 18, 26, 10, 7, 12, 21, 17, 9, 6, 16, 5, 15, 14 };
        int h = n / 2;
        for (int i = 0; i < sup; i++)
        {
            for (uint j = ~isp[i]; j != 0; j &= j - 1)
            {
                int pp = i << 5 | magic[((uint)(j & -j) * 124511785) >> 27];
                int p = 2 * pp + 3;
                if (p > n) break;
                yield return p;
                for (int q = pp; q <= h; q += p) isp[q >> 5] |= 1U << (q & 31);
            }
        }
    }
}
