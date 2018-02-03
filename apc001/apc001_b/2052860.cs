// detail: https://atcoder.jp/contests/apc001/submissions/2052860
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long diff = 0;
        for (int i = 0; i < a.Length; i++)
        {
            int d = b[i] - a[i];
            if (d <= 0)
            {
                diff -= d;
            }
            else
            {
                if(d % 2 == 1)
                {
                    d++;
                    diff++;
                }
                diff -= (d / 2);
            }
            //Console.WriteLine(diff);
        }
        Console.WriteLine(diff <= 0 ? "Yes" : "No");
    }
}
