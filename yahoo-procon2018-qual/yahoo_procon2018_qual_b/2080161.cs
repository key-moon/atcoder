// detail: https://atcoder.jp/contests/yahoo-procon2018-qual/submissions/2080161
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    public static void Main()
    {
        int[] xk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int lim = (int)Math.Pow(10, xk[1]);
        Console.WriteLine(((xk[0] / lim) + 1) * lim);
    }
}
