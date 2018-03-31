// detail: https://atcoder.jp/contests/atc002/submissions/2283265
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        long[] nmp = Console.ReadLine().Split().Select(long.Parse).ToArray();
        Console.WriteLine(power(nmp[0], nmp[2], nmp[1]));
    }
    static int power(long n, long m,long mod)
    {
        long pow = n;
        long res = 1;
        while (m > 0)
        {
            if ((m & 1) == 1) res = (res * pow) % mod;
            pow = (pow * pow) % mod;
            m >>= 1;
        }
        return (int)res;
    }
}
