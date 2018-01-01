// detail: https://atcoder.jp/contests/abc081/submissions/1932742
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int res = 0;
        while (true)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0) a[i] /= 2;
                else goto end;
            }
            res++;
        }
        end:;
        Console.WriteLine(res);
    }
}
