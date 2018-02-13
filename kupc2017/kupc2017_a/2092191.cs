// detail: https://atcoder.jp/contests/kupc2017/submissions/2092191
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] a = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToArray();

        int k = nk[1];
        for (int i = 0; i < a.Length; i++)
        {
            k -= a[i];
            if(k <= 0)
            {
                Console.WriteLine(i + 1);
                return;
            }
        }
        Console.WriteLine(-1);
    }
}
