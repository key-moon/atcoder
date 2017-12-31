// detail: https://atcoder.jp/contests/abc066/submissions/1931470
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(s.Sum() - s.Max());
    }
}
