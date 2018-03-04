// detail: https://atcoder.jp/contests/abc089/submissions/2155720
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[] s = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()[0]).ToArray();
        long[] count = new char[] { 'M', 'A', 'R', 'C', 'H' }.Select(x => s.LongCount(y => y == x)).ToArray();
        long res = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = i + 1; j < 5; j++)
            {
                for (int k = j + 1; k < 5; k++)
                {
                    res += count[i] * count[j] * count[k];
                }
            }
        }
        Console.WriteLine(res);
    }
}
