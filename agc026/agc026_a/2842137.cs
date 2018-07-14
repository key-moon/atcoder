// detail: https://atcoder.jp/contests/agc026/submissions/2842137
using System;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int currentCount = 0;
        int lastColor = -1;
        int p = 0;
        int res = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (lastColor != a[i])
            {
                res += currentCount / 2;
                currentCount = 0;
            }
            currentCount++;
            lastColor = a[i];
        }
        res += currentCount / 2;
        Console.WriteLine(res);
    }
}
