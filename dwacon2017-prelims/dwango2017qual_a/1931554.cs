// detail: https://atcoder.jp/contests/dwacon2017-prelims/submissions/1931554
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] nab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Math.Max((nab[1] + nab[2]) - nab[0], 0));
    }
}
