// detail: https://atcoder.jp/contests/cf16-final-open/submissions/2116167
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int m = Console.ReadLine().Split().Select(int.Parse).ToArray()[1];
        int[] a = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        int[] moda = new int[m];
        int[] paircount = new int[m];
        int res = 0;
        int last = -10;
        for (int i = 0; i < a.Length; i++)
        {
            if (last == a[i])
            {
                paircount[a[i] % m]++;
                last = -1;
            }
            else
            {
                last = a[i];
            }
            moda[a[i] % m]++;
        }

        if (m % 2 == 0)
        {
            res += moda[m / 2] / 2;
        }

        res += moda[0] / 2;
        
        for (int i = 0; i < m / 2 - (m % 2 == 0 ? 1 : 0); i++)
        {
            res += Math.Min(moda[i + 1], moda[m - i - 1]);
            res += Math.Min((moda[i + 1] > moda[m - i - 1] ? paircount[i + 1] : paircount[m - i - 1]) ,Math.Abs(moda[i + 1] - moda[m - i - 1]) / 2);
            //Console.WriteLine(res);
        }
        Console.WriteLine(res);
    }
}
