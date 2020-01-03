// detail: https://atcoder.jp/contests/arc098/submissions/9297707
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        int[] eSum = new int[n + 1];
        for (int i = 0; i < n; i++)
            eSum[i + 1] = eSum[i] + (s[i] == 'W' ? 1 : 0);
        int[] wSum = new int[n + 1];
        for (int i = n - 1; i >= 0; i--)
            wSum[i] = wSum[i + 1] + (s[i] == 'E' ? 1 : 0);
        Console.WriteLine(wSum.Skip(1).Zip(eSum, (x, y) => x + y).Min());
    }
}
