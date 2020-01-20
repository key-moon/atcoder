// detail: https://atcoder.jp/contests/arc004/submissions/9649292
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
        var xy = Console.ReadLine().Split('/').Select(long.Parse).ToArray();
        var X = xy[0];
        var Y = xy[1];
        var gcd = GCD(X, Y);
        X /= gcd;
        Y /= gcd;
        if (Y % 2 == 0) Y /= 2;
        else X *= 2;
        var nMin = X / Y - 1;
        var nMax = X / Y + 1 + 1 - 1;
        bool possible = false;
        for (long n = nMin; n <= nMax; n++)
        {
            if (n % Y != 0) continue;
            var mul = n / Y;
            var realX = X * mul;
            var realY = Y * mul;
            var twoM = n * n + n - realX;
            if (twoM % 2 != 0) continue;
            var m = twoM / 2;
            if (m < 1 || n < m) continue;
            possible = true;
            Console.WriteLine($"{n} {m}");
        }

        if (!possible) Console.WriteLine("Impossible");
    }

    static long GCD(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            a %= b;
            if (a == 0) return b;
            b %= a;
        }
    }
}
