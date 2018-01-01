// detail: https://atcoder.jp/contests/abc024/submissions/1932357
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] abck = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] st = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(st[0] * abck[0] + st[1] * abck[1] - (st[0] + st[1] - abck[3] >= 0 ? (st[0] + st[1]) * abck[2] : 0));
    }
}
