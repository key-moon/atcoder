// detail: https://atcoder.jp/contests/utpc2012/submissions/2209748
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] a = new int[10];
        string[] b = Console.ReadLine().Split('/');
        for (int i = 0; i < 4; i++)
        {
            a[b[0][i] - '0']++;
        }
        for (int i = 0; i < 2; i++)
        {
            a[b[1][i] - '0']--;
        }
        for (int i = 0; i < 2; i++)
        {
            a[b[2][i] - '0']--;
        }
        string res = "no";
        if (a.Count(x => x != 0) == 0) res = "yes";
        Console.WriteLine(res);
    }
}
