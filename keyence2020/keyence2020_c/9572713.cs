// detail: https://atcoder.jp/contests/keyence2020/submissions/9572713
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
        var nks = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nks[0];
        var k = nks[1];
        var s = nks[2];

        Console.WriteLine(string.Join(" ", Enumerable.Repeat(s, k).Concat(Enumerable.Repeat(s == ((int)1e9) ? s - 1 : s + 1, n - k))));
    }
}
