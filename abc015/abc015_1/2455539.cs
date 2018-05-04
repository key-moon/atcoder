// detail: https://atcoder.jp/contests/abc015/submissions/2455539
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;
class P
{
    static void Main()
    {
        Console.WriteLine(Enumerable.Repeat(0, 2).Select(_ => Console.ReadLine()).OrderBy(x => x.Length).Last());
    }
}
