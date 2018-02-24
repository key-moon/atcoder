// detail: https://atcoder.jp/contests/abc046/submissions/2127428
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        long[] temp = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long t = temp[0];
        long a = temp[1];
        for (long i = 1; i < n; i++)
        {
            long[] ta = Console.ReadLine().Split().Select(long.Parse).ToArray();
            long pow = Math.Max(t / ta[0] + (t % ta[0] != 0 ? 1 : 0), a / ta[1] + (a % ta[1] != 0 ? 1 : 0));
            t = ta[0] * pow;
            a = ta[1] * pow;
        }
        Console.WriteLine(t + a);
    }
    static long lcm(long a, long b)
    {
        return a * b / gcd(a, b);
    }
    static long gcd(long a, long b)
    {
        if (a < b) return gcd(b, a);
        long d = 0;
        do
        {
            d = a % b;
            a = b;
            b = d;
        } while (d != 0);
        return a;
    }
}
