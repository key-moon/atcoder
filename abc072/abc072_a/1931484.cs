// detail: https://atcoder.jp/contests/abc072/submissions/1931484
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Math.Max(s[0] - s[1],0));
    }
}
