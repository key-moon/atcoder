// detail: https://atcoder.jp/contests/abc037/submissions/1954486
using System;
using System.Linq;
using System.Collections.Generic;
 
class P
{
    static void Main()
    {
        int[] NK = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long[] T = Console.ReadLine().Split().Select(long.Parse).ToArray();
        int n = Math.Min(NK[0] + 1 - NK[1], NK[1]);
        int[] p = Enumerable.Repeat(n, NK[0]).ToArray();
        for (int i = 0; i < n; i++)
        {
            p[i] = i + 1;
            p[NK[0] - 1 - i] = i + 1;
        }
        Console.WriteLine(T.Zip(p, (x, y) => x * y).Sum());
    }
}
