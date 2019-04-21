// detail: https://atcoder.jp/contests/colopl2018-qual/submissions/5077748
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var ab = Console.ReadLine().Split().Select(long.Parse).ToArray();

        var primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };
        //2,3,5,7,11,13,17,19,23,29,31の倍数であるかどうかの状態
        long[] table = new long[1 << 11];
        table[0] = 1;
        for (long i = ab[0]; i <= ab[1]; i++)
        {
            int elemFactorMask = 0;
            for (int j = 0; j < primes.Length; j++)
                if (i % primes[j] == 0) elemFactorMask |= (1 << j);
            
            for (int j = 0; j < table.Length; j++)
                if ((j & elemFactorMask) == 0)
                    table[j | elemFactorMask] += table[j];
        }
        Console.WriteLine(table.Sum());
    }
}
