// detail: https://atcoder.jp/contests/abc086/submissions/2294984
using System;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        Console.WriteLine(Console.ReadLine().Split().Select(x => int.Parse(x)).Aggregate((x, y) => x * y) % 2 == 0 ? "Even":"Odd");
    }
}
