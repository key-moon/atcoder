// detail: https://atcoder.jp/contests/joi2008yo/submissions/2096467
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int res = 0;
        int[] coin = { 500, 100, 50, 10, 5, 1 };
        int n = 1000 - int.Parse(Console.ReadLine());
        for (int i = 0; i < coin.Length; i++)
        {
            res += n / coin[i];
            n %= coin[i];
        }
        Console.WriteLine(res);
    }
}
