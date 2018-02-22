// detail: https://atcoder.jp/contests/joi2014yo/submissions/2123630
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        Console.WriteLine(Enumerable.Repeat(0, 5).Select(_ => Math.Max(40,int.Parse(Console.ReadLine()))).Average());
    }
}
