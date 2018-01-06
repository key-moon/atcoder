// detail: https://atcoder.jp/contests/agc019/submissions/1943157
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] qhsd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long n = int.Parse(Console.ReadLine());
        long lit = Math.Min(Math.Min(qhsd[0] * 4, qhsd[1] * 2), qhsd[2]);
        bool is2lisChaper = lit * 2 > qhsd[3];
        Console.WriteLine(is2lisChaper ? (n / 2) * qhsd[3] + (n % 2) * lit : n * lit);
    }
}
