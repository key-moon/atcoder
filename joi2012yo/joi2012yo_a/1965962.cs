// detail: https://atcoder.jp/contests/joi2012yo/submissions/1965962
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.WriteLine(Math.Min(int.Parse(Console.ReadLine()),Math.Min(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()))) + Math.Min(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())) - 50);
    }
}
