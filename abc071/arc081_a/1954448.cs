// detail: https://atcoder.jp/contests/abc071/submissions/1954448
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        long[] ns = Console.ReadLine().Split().Select(long.Parse).OrderByDescending(x => x).ToArray();
        int count = 0;
        long res = 1;
        long last = 0;
        for (int i = 0; i < ns.Length; i++)
        {
            if (ns[i] == last)
            {
                res *= ns[i];
                count++;
                last = -1;
                if (count >= 2) break;
            }
            else
            {
                last = ns[i];
            }
        }
        if (count < 2)
        {
            Console.WriteLine(0);
        }
        else
        {
            Console.WriteLine(res);
        }
    }
}
