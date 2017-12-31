// detail: https://atcoder.jp/contests/abc075/submissions/1931497
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] A = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(A.Count(x => x == A.Max()) == 1? A.Max() : A.Min());
    }
}
