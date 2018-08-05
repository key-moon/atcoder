// detail: https://atcoder.jp/contests/abc104/submissions/2957314
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(n < 1200 ? "ABC" : (n < 2800 ? "ARC" : "AGC"));
    }
}
