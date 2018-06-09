// detail: https://atcoder.jp/contests/code-thanks-festival-2014-a-open/submissions/2640843
using System;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] abc = Enumerable.Repeat(0, 3).Select(_ => int.Parse(Console.ReadLine())).OrderByDescending(x => x).ToArray();
        int count = 0;
        while (n > 0)
        {
            n -= abc[count % 3];
            count++;
        }
        Console.WriteLine(count);
    }
}
