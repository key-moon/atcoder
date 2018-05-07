// detail: https://atcoder.jp/contests/chokudai_S001/submissions/2476965
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
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int count = 0;
        int max = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (max < a[i]) count++;
            max = Max(a[i], max);
        }
        Console.WriteLine(count);
    }
}
