// detail: https://atcoder.jp/contests/abc085/submissions/1948019
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //Console.WriteLine(Console.ReadLine().Replace("2017", "2018"));
        for (int i = 0; i <= a[0]; i++)
        {
            for (int j = 0; j <= a[0] - i; j++)
            {
                if(a[1] == i * 1000 + j * 5000 + (a[0] - i - j) * 10000)
                {
                    Console.WriteLine($"{(a[0] - i - j)} {j} {i}");
                    return;
                }
            }
        }
        Console.WriteLine("-1 -1 -1");
    }
}
