// detail: https://atcoder.jp/contests/sumitrust2019/submissions/8725901
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
        var a = Console.ReadLine().Split().Select(int.Parse).First();
        var b = Console.ReadLine().Split().Select(int.Parse).First();

        Console.WriteLine(a != b ? 1 : 0);
    }
}
