// detail: https://atcoder.jp/contests/abc069/submissions/1931477
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((s[0] - 1) * (s[1] - 1));
    }
}
