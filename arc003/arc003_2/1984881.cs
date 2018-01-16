// detail: https://atcoder.jp/contests/arc003/submissions/1984881
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.WriteLine(string.Join("
", Enumerable.Repeat("", int.Parse(Console.ReadLine())).Select(_ => Console.ReadLine()).OrderBy(x => string.Join("", x.Reverse().ToArray())).ToArray()));
    }
}
