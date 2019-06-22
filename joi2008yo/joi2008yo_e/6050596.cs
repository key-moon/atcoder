// detail: https://atcoder.jp/contests/joi2008yo/submissions/6050596
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
        var reader = Console.In;
        var rc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var r = rc[0];
        var c = rc[1];
        uint[] senbeis = new uint[c];
        for (int i = 0; i < r; i++)
        {
            var j = 0;
            foreach (var item in Console.ReadLine().Split().Select(uint.Parse))
            {
                senbeis[j] |= item << i;
                j++;
            }
        }
        int max = 0;
        for (uint i = 0; i < (1 << r); i++)
        {
            int sum = 0;
            for (int j = 0; j < senbeis.Length; j++)
            {
                var popcount = PopCount(senbeis[j] ^ i);
                sum += Max(r - popcount, popcount);
            }
            max = Max(max, sum);
        }
        Console.WriteLine(max);
    }

    static int PopCount(uint n)
    {
        n = n - ((n >> 1) & 0x55555555U);
        n = (n & 0x33333333U) + ((n >> 2) & 0x33333333U);
        return (int)(((n + (n >> 4) & 0xF0F0F0FU) * 0x1010101U) >> 24);
    }
}
