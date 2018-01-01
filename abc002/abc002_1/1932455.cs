// detail: https://atcoder.jp/contests/abc002/submissions/1932455
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(a.Max());
    }
}
