// detail: https://atcoder.jp/contests/abc064/submissions/1931460
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((s[0] * 100 + s[1] * 10 + s[2]) % 4 == 0 ? "YES" : "NO");
    }
}
