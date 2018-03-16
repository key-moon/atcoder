// detail: https://atcoder.jp/contests/code-thanks-festival-2014-a-open/submissions/2210762
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        Console.WriteLine(Console.ReadLine().Split().Select((x, y) => int.Parse(x) * (2 - y) * 2).Sum());
    }
}
