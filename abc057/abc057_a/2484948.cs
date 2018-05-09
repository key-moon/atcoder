// detail: https://atcoder.jp/contests/abc057/submissions/2484948
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).Sum() % 24);
    }
}
