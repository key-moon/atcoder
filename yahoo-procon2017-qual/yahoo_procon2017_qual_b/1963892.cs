// detail: https://atcoder.jp/contests/yahoo-procon2017-qual/submissions/1963892
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        long[] nk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        Console.WriteLine(Console.ReadLine().Split().Select(long.Parse).OrderBy(x => x).Take((int)nk[1]).Sum() + (nk[1] - 1) * (nk[1]) / 2);
    }
}
