// detail: https://atcoder.jp/contests/abc071/submissions/1931483
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Math.Abs(s[1] - s[0]) > Math.Abs(s[2] - s[0]) ? "B" : "A");
    }
}
