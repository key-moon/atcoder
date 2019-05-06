// detail: https://atcoder.jp/contests/abc117/submissions/5290260
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
using System.Runtime.CompilerServices;

static class P
{
    static void Main()
    {
        var n = Read();
        var k = Read();
        int[] bitCount = new int[40];
        for (int i = 0; i < n; i++)
        {
            var value = Read();
            for (int j = 0; j < 40; j++) bitCount[j] += (int)((value >> j) & 1);
        }
        long restrictedMax = 0;
        long freeMax = 0;
        for (int i = 0; i < 40; i++)
        {
            var scoreOne = (n - bitCount[i]) * (1L << i);
            var scoreZero = bitCount[i] * (1L << i);
            if (((k >> i) & 1) == 1) restrictedMax = Max(freeMax + scoreZero, restrictedMax + Max(scoreZero, scoreOne));
            else restrictedMax += scoreZero;
            freeMax += Max(scoreZero, scoreOne);
        }
        Console.WriteLine(restrictedMax);
    }

    static readonly TextReader In = Console.In;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static long Read()
    {
        long res = 0;
        int next = In.Read();
        while (48 > next || next > 57) next = In.Read();
        while (48 <= next && next <= 57)
        {
            res = res * 10 + next - 48;
            next = In.Read();
        }
        return res;
    }
}
