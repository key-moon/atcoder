// detail: https://atcoder.jp/contests/joi2009yo/submissions/2097072
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        Console.WriteLine(string.Join(" ",Enumerable.Repeat(0,2).Select(_ => Enumerable.Repeat(0, 10).Select(__ => int.Parse(Console.ReadLine())).OrderByDescending(x => x).Take(3).Sum()).ToArray()));
    }
}
