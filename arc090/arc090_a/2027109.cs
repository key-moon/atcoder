// detail: https://atcoder.jp/contests/arc090/submissions/2027109
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int res = 0;
        for (int i = 0; i < a.Length; i++)
        {
            res = Math.Max(a.Take(i + 1).Sum() + b.Skip(i).Sum(), res);
        }
        Console.WriteLine(res);
    }
}
