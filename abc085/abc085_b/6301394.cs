// detail: https://atcoder.jp/contests/abc085/submissions/6301394
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
        var n = int.Parse(Console.ReadLine());
        Console.WriteLine(Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).Distinct().Count());
    }
}
