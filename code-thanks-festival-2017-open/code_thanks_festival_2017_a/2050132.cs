// detail: https://atcoder.jp/contests/code-thanks-festival-2017-open/submissions/2050132
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.WriteLine(new int[8].Select(_ => int.Parse(Console.ReadLine())).ToArray().Max());
    }
}
