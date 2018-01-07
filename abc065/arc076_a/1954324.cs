// detail: https://atcoder.jp/contests/abc065/submissions/1954324
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] ns = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long n = 1;
        for (int i = 1; i <= ns[0]; i++) n = (n * i) % 1000000007;
        long s = 1;
        for (int i = 1; i <= ns[1]; i++) s = (s * i) % 1000000007;
        long res = 0;
        if (ns[0] == ns[1]) res = (n * s * 2) % 1000000007;
        else if (Math.Abs(ns[0] - ns[1]) == 1) res = (n * s) % 1000000007;
        Console.WriteLine(res);
    }
}
