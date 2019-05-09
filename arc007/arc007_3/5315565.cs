// detail: https://atcoder.jp/contests/arc007/submissions/5315565
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

static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        var length = s.Length;
        var pattern = 0;
        for (int i = 0; i < length; i++)
        {
            pattern <<= 1;
            if (s[i] == 'o') pattern |= 1;
        }
        pattern |= pattern << length;
        int res = int.MaxValue;
        for (int i = 0; i < (1 << length); i++)
        {
            var mask = 0;
            for (int j = 0; j < length; j++)
                if (((i >> j) & 1) == 1) mask |= pattern << j;
            if (PopCount((mask >> length) & ((1 << length) - 1)) == length) res = Min(res, PopCount(i));
        }
        Console.WriteLine(res);
    }

    static int PopCount(int n)
    {
        int msb = 0;
        if (n < 0) { n &= int.MaxValue; msb = 1; }
        n = n - ((n >> 1) & 0x55555555);
        n = (n & 0x33333333) + ((n >> 2) & 0x33333333);
        return (((n + (n >> 4) & 0xF0F0F0F) * 0x1010101) >> 24) + msb;
    }
}
