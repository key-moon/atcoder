// detail: https://atcoder.jp/contests/abc052/submissions/2095582
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] p = Enumerable.Repeat(1, n + 1).ToArray();
        for (int i = 1; i <= n; i++)
        {
            int[] f = factors(i);
            for (int j = 0; j < f.Length; j++)
            {
                p[f[j]]++;
            }
        }
        Console.WriteLine(product(p));
    }

    static int product(int[] a)
    {
        int mod = 1000000007;
        long res = 1;
        for (int i = 0; i < a.Length; i++) res = (res * a[i]) % mod;
        return (int)res;
    }
    static int[] factors(int n)
    {
        int i = 2;
        List<int> res = new List<int>();
        while (i * i <= n)
        {
            if (n % i == 0)
            {
                res.Add(i);
                n /= i;
            }
            else
            {
                i++;
            }
        }
        if (n != 1) res.Add(n);
        return res.ToArray();
    }
}
