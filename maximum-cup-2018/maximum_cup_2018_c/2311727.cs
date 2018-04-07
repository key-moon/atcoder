// detail: https://atcoder.jp/contests/maximum-cup-2018/submissions/2311727
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine()) - 1).ToArray();
        int[] count = new int[n];
        for (int i = 0; i < n; i++)
        {
            if(count[i] == 0)
            {
                int curInd = i;
                int curcount = 1;
                while (count[curInd] == 0)
                {
                    count[curInd] = curcount;
                    curcount++;
                    curInd = a[curInd];
                }
                if (count[curInd] % 2 != curcount % 2) goto end;
            }
        }
        int res = 0;
        int angCount = count.Count(x => x % 2 == 0);
        res = Max(angCount, n - angCount);
        Console.WriteLine(res);
        return;
        end: Console.WriteLine(-1);
    }
}
