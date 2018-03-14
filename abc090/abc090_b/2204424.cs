// detail: https://atcoder.jp/contests/abc090/submissions/2204424
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int res = 0;
        for (int i = a[0]; i <= a[1]; i++)
        {
            var s = i.ToString();
            if (s[0] == s[4] && s[1] == s[3]) res++;
        }
        Console.WriteLine(res);
    }
}
