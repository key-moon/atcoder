// detail: https://atcoder.jp/contests/joi2007yo/submissions/2096426
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        Console.WriteLine(string.Join("
", Enumerable.Range(1, 30).Except(Enumerable.Repeat(0, 28).Select(_ => int.Parse(Console.ReadLine()))).ToArray()));
    }
}
