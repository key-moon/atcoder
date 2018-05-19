// detail: https://atcoder.jp/contests/abc072/submissions/2530623
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        Console.WriteLine(Max(0, Console.ReadLine().Split().Select(int.Parse).Aggregate((x, y) => x - y)));
    }
}
