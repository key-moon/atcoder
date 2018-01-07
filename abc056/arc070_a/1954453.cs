// detail: https://atcoder.jp/contests/abc056/submissions/1954453
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.WriteLine((long)Math.Ceiling(-0.5 + Math.Sqrt(1 + 8 * long.Parse(Console.ReadLine())) / 2));
    }
}
