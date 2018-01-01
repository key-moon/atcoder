// detail: https://atcoder.jp/contests/abc060/submissions/1932866
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] NMA = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool[] N = new bool[NMA[1]];
        int i = 0;
        while (true)
        {
            int a = NMA[0] * i % NMA[1];
            if (N[a]) break;
            N[a] = true;
            i++;
        }
        Console.WriteLine(N[NMA[2]] ? "YES" : "NO");
    }
}
