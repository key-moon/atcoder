// detail: https://atcoder.jp/contests/abc046/submissions/1933013
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] NK = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int res = NK[1];
        for (int i = 1; i < NK[0]; i++)
        {
            res *= NK[1] - 1;
        }
        Console.WriteLine(res);
    }
}
