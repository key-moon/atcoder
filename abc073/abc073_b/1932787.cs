// detail: https://atcoder.jp/contests/abc073/submissions/1932787
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int res = 0;
        for (int i = 0; i < N; i++)
        {
            int[] x = Console.ReadLine().Split().Select(int.Parse).ToArray();
            res += (x[1] - x[0]) + 1;
        }
        Console.WriteLine(res);
    }
}
