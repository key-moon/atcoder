// detail: https://atcoder.jp/contests/abc056/submissions/1932903
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] wab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Math.Max(Math.Abs(wab[2] - wab[1]) - wab[0],0));
    }
}
