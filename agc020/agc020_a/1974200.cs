// detail: https://atcoder.jp/contests/agc020/submissions/1974200
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int n = int.Parse(Console.ReadLine());
        int[] nab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((nab[2] - nab[1]) % 2 == 0 ? "Alice" : "Borys");
    }
}
