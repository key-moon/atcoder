// detail: https://atcoder.jp/contests/s8pc-5/submissions/2362445
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nt = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        double nowTime = 0;
        for (int i = 0; i < a.Length; i++)
        {
            nowTime = (Ceiling((nowTime - a[i]) / nt[1])) * nt[1] + a[i];
        }
        Console.WriteLine(nowTime);
    }
}
