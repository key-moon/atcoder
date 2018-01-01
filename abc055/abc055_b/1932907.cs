// detail: https://atcoder.jp/contests/abc055/submissions/1932907
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int[] wab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int a = int.Parse(Console.ReadLine());
        long res = 1;
        for (long i = 1; i <= a; i++) res = res * i % 1000000007;
        Console.WriteLine(res);
    }
}
