// detail: https://atcoder.jp/contests/abc082/submissions/1931501
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] A = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((int)Math.Ceiling(A.Average()));
    }
}
