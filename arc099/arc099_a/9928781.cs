// detail: https://atcoder.jp/contests/arc099/submissions/9928781
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((nk[0] - 1 + nk[1] - 1 - 1) / (nk[1] - 1));
    }
}
