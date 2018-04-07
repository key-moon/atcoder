// detail: https://atcoder.jp/contests/maximum-cup-2018/submissions/2310752
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
        int[][] tdms = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int count = 0;
        foreach (var tdm in tdms)
        {
            if ((tdm[0] + 10) <= tdm[1])
            {
                count += tdm[2];
            }
        }
        Console.WriteLine(count);
    }
}
