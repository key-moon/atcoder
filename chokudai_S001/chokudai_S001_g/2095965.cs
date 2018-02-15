// detail: https://atcoder.jp/contests/chokudai_S001/submissions/2095965
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int mod = 1000000007;
        long last = 0;
        for (int i = 0; i < a.Length; i++)
        {
            last = long.Parse($"{last}{a[i]}") % mod;
        }
        Console.WriteLine(last);
    }
}
