// detail: https://atcoder.jp/contests/abc081/submissions/2127312
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] a = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        List<int> count = new List<int>();

        int last = a[0];
        int ncount = 1;
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] == last) ncount++;
            else
            {
                last = a[i];
                count.Add(ncount);
                ncount = 1;
            }
        }
        count.Add(ncount);
        int[] ocount = count.OrderBy(x => x).ToArray();
        Console.WriteLine(ocount.Take(Math.Max(0, ocount.Length - nk[1])).Sum());
    }
}
