// detail: https://atcoder.jp/contests/abc069/submissions/1935215
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int other = 0;
        int multi2 = 0;
        int multi4 = 0;

        foreach (var i in a)
        {
            if (i % 2 == 0)
            {
                if (i % 4 == 0)
                {
                    multi4++;
                }
                else
                {
                    multi2++;
                }
            }
            else
            {
                other++;
            }
        }
        if (other <= multi4 || (other - 1 == multi4 && multi2 == 0))
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}
