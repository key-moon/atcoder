// detail: https://atcoder.jp/contests/abc058/submissions/1931445
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(s[1] - s[0] == s[2] - s [1] ? "YES" : "NO");
    }
}
