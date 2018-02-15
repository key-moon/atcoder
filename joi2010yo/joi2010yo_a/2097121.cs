// detail: https://atcoder.jp/contests/joi2010yo/submissions/2097121
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        Console.WriteLine(int.Parse(Console.ReadLine()) - Enumerable.Repeat(0, 9).Select(_ => int.Parse(Console.ReadLine())).Sum());
    }
}
