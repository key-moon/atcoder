// detail: https://atcoder.jp/contests/abc071/submissions/6300510
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
        var xab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Abs(xab[0] - xab[1]) > Abs(xab[0] - xab[2]) ? "B" : "A");
    }
}
