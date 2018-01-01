// detail: https://atcoder.jp/contests/abc061/submissions/1932851
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] NM = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] N = new int[NM[0]];
        for (int i = 0; i < NM[1]; i++)
        {
            int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
            N[a[0] - 1]++;
            N[a[1] - 1]++;
        }
        for (int i = 0; i < NM[0]; i++)
        {
            Console.WriteLine(N[i]);
        }
    }
}
