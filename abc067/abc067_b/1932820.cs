// detail: https://atcoder.jp/contests/abc067/submissions/1932820
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int k = Console.ReadLine().Split().Select(int.Parse).ToArray()[1];
        int[] N = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(N.OrderByDescending(x => x).Take(k).Sum());
    }
}
