// detail: https://atcoder.jp/contests/abc149/submissions/9207201
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
        Console.WriteLine(Primes(200000).First(x => n <= x));
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
