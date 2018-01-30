// detail: https://atcoder.jp/contests/abc086/submissions/2040185
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(a[0] * a[1] % 2 == 0 ? "Even" : "Odd");
    }
}
