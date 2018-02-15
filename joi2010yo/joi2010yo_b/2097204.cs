// detail: https://atcoder.jp/contests/joi2010yo/submissions/2097204
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] map = Enumerable.Repeat(0, nm[0]).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        int[] me = Enumerable.Repeat(0, nm[1]).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        int masu = 0;
        for (int i = 0; i < me.Length; i++)
        {
            masu += me[i];
            if (map.Length - 1 <= masu)
            {
                Console.WriteLine(i + 1);
                return;
            }
            masu += map[masu];
            if (map.Length - 1 <= masu)
            {
                Console.WriteLine(i+ 1);
                return;
            }
        }
    }
}
