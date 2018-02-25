// detail: https://atcoder.jp/contests/abc072/submissions/2134986
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] x = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int count = 0;
        bool last = false;
        for (int i = 0; i < x.Length; i++)
        {
            if (x[i] == i + 1)
            {
                if (last)
                {
                    count++;
                    last = false;
                }
                else
                {
                    last = true;
                }
            }
            else if (last)
            {
                count++;
                last = false;
            }
        }
        if (last)
        {
            count++;
        }
        Console.WriteLine(count);
    }
}
