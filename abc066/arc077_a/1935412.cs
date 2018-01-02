// detail: https://atcoder.jp/contests/abc066/submissions/1935412
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] b = new int[a.Length];
        if (a.Length % 2 == 0)
        {
            for (int i = 0; i < a.Length; i++)
            {
                b[a.Length / 2 + (i % 2 == 0 ? 1 : -1) * (i + 1) / 2] = a[i];
            }
        }
        else
        {
            for (int i = 0; i < a.Length; i++)
            {
                b[a.Length / 2 + (i % 2 == 0 ? -1 : 1) * (i + 1) / 2] = a[i];
            }
        }
        Console.WriteLine(string.Join(" ", b));
    }
}
