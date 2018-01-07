// detail: https://atcoder.jp/contests/abc060/submissions/1954458
using System;
using System.Linq;
using System.Collections.Generic;
 
class P
{
    static void Main()
    {
        int[] NT = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long sec = 0;
        int[] T = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int lastsec = T[0];
        for (int i = 1; i < NT[0]; i++)
        {
            int a = T[i];
            sec += Math.Min(NT[1], a - lastsec);
            lastsec = a;
        }
        sec += NT[1];
        Console.WriteLine(sec);
    }
}
