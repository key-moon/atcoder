// detail: https://atcoder.jp/contests/code-festival-2017-qualc/submissions/2092022
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();

        long res = 1;
        for (int i = 0; i < nm.Length; i++)
        {
            res *= (((nm[i] + 1) % 2) + 1);
        }
        Console.WriteLine(power(3,n) - res);
    }

    static int power(int n, int m)
    {
        const int mod = 1000000007;
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
