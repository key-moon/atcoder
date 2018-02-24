// detail: https://atcoder.jp/contests/abc055/submissions/2127292
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        long[] nm = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long allc = nm[0] * 2 + nm[1];
        long possibleS = allc / 4;
        Console.WriteLine(Math.Min(possibleS, nm[1] / 2));
    }
}
