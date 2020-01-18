// detail: https://atcoder.jp/contests/keyence2020/submissions/9571383
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
        var h = int.Parse(Console.ReadLine());
        var w = int.Parse(Console.ReadLine());
        var n = int.Parse(Console.ReadLine());
        var max = Max(h, w);
        Console.WriteLine((n + max - 1) / max);
    }
}
