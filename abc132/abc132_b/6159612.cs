// detail: https://atcoder.jp/contests/abc132/submissions/6159612
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var p = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int count = 0;
        for (int i = 1; i < n - 1; i++)
        {
            if ((p[i - 1] < p[i] && p[i] < p[i + 1]) || p[i - 1] > p[i] && p[i] > p[i + 1])
                count++;
        }
        Console.WriteLine(count);
    }
}
