// detail: https://atcoder.jp/contests/soundhound2018/submissions/2021863
using System;
using System.Linq;
using System.Net;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] nLR = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] res = new int[nLR[0]];
        for (int i = 0; i < res.Length; i++)
        {
            res[i] = Math.Min(Math.Max(nLR[1], a[i]), nLR[2]);
        }
        Console.WriteLine(string.Join(" ",res));
    }
}
