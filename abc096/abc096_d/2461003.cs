// detail: https://atcoder.jp/contests/abc096/submissions/2461003
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        //(5n+1)*5=
        int[] p = prime(55555).Where(x => x % 5 == 1).Take(n).ToArray();
        Console.WriteLine(string.Join(" ", p));
    }

    static int[] prime(int max)
    {
        if (max < 2) return new int[0];
        List<int> res = new List<int>();
        int sqrtMax = (int)Math.Sqrt(max);
        List<int> sieve = Enumerable.Range(2, max - 2).ToList();
        while (sieve.Count != 0)
        {
            int p = sieve[0];
            if (p > sqrtMax) break;
            res.Add(p);
            sieve.RemoveAll(x => x % p == 0);
        }
        res.AddRange(sieve);
        return res.ToArray();
    }
}
