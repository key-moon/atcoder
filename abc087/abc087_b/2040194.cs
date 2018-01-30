// detail: https://atcoder.jp/contests/abc087/submissions/2040194
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());
        int res = 0;
        for (int i = 0; i <= a; i++)
        {
            for (int j = 0; j <= b; j++)
            {
                for (int k = 0 ; k <= c; k++)
                {
                    if (i * 500 + j * 100 + k * 50 == x) res++;
                }
            }
        }
        Console.WriteLine(res);
    }
}
