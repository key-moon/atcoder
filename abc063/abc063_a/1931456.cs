// detail: https://atcoder.jp/contests/abc063/submissions/1931456
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(s.Sum() >= 10 ? "error" : s.Sum().ToString());
    }
}
