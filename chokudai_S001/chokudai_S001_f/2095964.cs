// detail: https://atcoder.jp/contests/chokudai_S001/submissions/2095964
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int res = 1;
        int max = a[0];
        for (int i = 1; i < a.Length; i++)
        {
            if (max < a[i])
            {
                res++;
                max = a[i];
            }
        }
        Console.WriteLine(res);
    }
}
