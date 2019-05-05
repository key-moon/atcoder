// detail: https://atcoder.jp/contests/cpsco2019-s3/submissions/5277348
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] digitCount = new int[30];
        int currentXor = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 30; j++)
            {
                if (((a[i] >> j) & 1) == 1) digitCount[j]++;
            }
            currentXor ^= a[i];
            long res = 0;
            for (int j = 0; j < 30; j++)
            {
                res += (long)(((currentXor >> j) & 1) == 1 ? i + 1 - digitCount[j] : digitCount[j]) << j;
            }
            Console.WriteLine(res);
        }
    }
}
