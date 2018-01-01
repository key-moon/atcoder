// detail: https://atcoder.jp/contests/abc034/submissions/1932290
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((a[1] > a[0]?  "Better": "Worse"));
    }
}
