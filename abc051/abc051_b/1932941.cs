// detail: https://atcoder.jp/contests/abc051/submissions/1932941
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] KS = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int res = 0;
        for (int i = 0; i <= KS[0]; i++)
        {
            for (int j = 0; j <= KS[0]; j++)
            {
                if (0 <= KS[1] - (i + j) && KS[1] - (i + j) <= KS[0]) res++;
            }
        }
        Console.WriteLine(res);
    }
}
