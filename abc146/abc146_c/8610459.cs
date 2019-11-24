// detail: https://atcoder.jp/contests/abc146/submissions/8610459
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;

public static class P
{
    public static void Main()
    {
        var abx = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var a = abx[0];
        var b = abx[1];
        var x = abx[2];
        long res = 0;
        for (int min = 1000000000, d = 10; min >= 1; min /= 10, d--)
        {
            if (min * a + d * b > x) continue;
            res = Min(min * 10 - 1, (x - d * b) / a);
            break;
        }
        Console.WriteLine(Min(res, (long)1e9));
    }
}
