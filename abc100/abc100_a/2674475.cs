// detail: https://atcoder.jp/contests/abc100/submissions/2674475
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(ab.All(x => x <= 8) ? "Yay!" : ":(");
    }
}
