// detail: https://atcoder.jp/contests/arc048/submissions/1957589
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(a[1] - a[0] - (a[0] < 0 ? 1 : 0) + (a[1] < 0 ? 1 : 0));
    }
}
