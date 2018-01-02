// detail: https://atcoder.jp/contests/abc068/submissions/1935287
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] NM = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<int> from1Ship = new List<int>();
        List<int> toNShip = new List<int>();
        for (int i = 0; i < NM[1]; i++)
        {
            int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (a[0] == 1) from1Ship.Add(a[1]);
            if (a[1] == NM[0]) toNShip.Add(a[0]);
        }
        int[] f1 = from1Ship.OrderBy(x => x).ToArray();
        int[] tN = toNShip.OrderBy(x => x).ToArray();
        int f1index = 0;
        int tnindex = 0;
        while (f1index < f1.Length && tnindex < tN.Length)
        {
            if (f1[f1index] < tN[tnindex]) f1index++;
            else if (f1[f1index] > tN[tnindex]) tnindex++;
            else
            {
                Console.WriteLine("POSSIBLE");
                return;
            }
        }
        Console.WriteLine("IMPOSSIBLE");
    }
}
