// detail: https://atcoder.jp/contests/abc005/submissions/1942745
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int res = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            res = Math.Min(int.Parse(Console.ReadLine()), res);
        }
        Console.WriteLine(res);
    }
}
