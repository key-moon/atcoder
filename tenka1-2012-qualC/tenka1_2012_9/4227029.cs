// detail: https://atcoder.jp/contests/tenka1-2012-qualC/submissions/4227029
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        Console.WriteLine(prime(int.Parse(Console.ReadLine())).Count());
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
