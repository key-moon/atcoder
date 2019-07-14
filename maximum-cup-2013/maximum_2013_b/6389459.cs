// detail: https://atcoder.jp/contests/maximum-cup-2013/submissions/6389459
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        while (true)
        {
            var num = long.Parse(Console.ReadLine());
            if (num == 0) break;
            Console.WriteLine(Factors(num).Max());
        }
    }


    static IEnumerable<long> Factors(long n)
    {
        while (n % 2 == 0)
        {
            n /= 2;
            yield return 2;
        }
        long i = 3;
        while (i * i <= n)
        {
            if (n % i == 0)
            {
                n /= i;
                yield return i;
            }
            else i += 2;
        }
        if (n != 1) yield return n;
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
