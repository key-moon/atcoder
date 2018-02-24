// detail: https://atcoder.jp/contests/agc020/submissions/2127218
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] nab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((nab[2] - nab[1]) % 2 == 0 ? "Alice" : "Borys");
    }
}
