// detail: https://atcoder.jp/contests/abc099/submissions/2927196
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static readonly int[] diffs = { 1, 6, 36, 216, 1296, 7776, 46656, 9, 81, 729, 6561, 59049 };
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();
        a[0] = 0;
        for (int i = 0; i < a.Length; i++)
        {
            foreach (var diff in diffs)
            {
                if (diff + i >= a.Length) continue;
                a[diff + i] = Min(a[diff + i], a[i] + 1);
            }
        }
        Console.WriteLine(a.Last());
    }
}
