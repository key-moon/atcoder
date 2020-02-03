// detail: https://atcoder.jp/contests/abc086/submissions/9889809
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
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).Any(x => x % 2 == 0) ? "Even" : "Odd");
    }
}
