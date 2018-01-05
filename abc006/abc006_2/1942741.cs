// detail: https://atcoder.jp/contests/abc006/submissions/1942741
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        switch (n)
        {
            case 1:
            Console.WriteLine(0);
            return;
            case 2:
            Console.WriteLine(0);
            return;
            case 3:
            Console.WriteLine(1);
            return;
        }
        long a1 = 0;
        long a2 = 0;
        long a3 = 1;
        long a;
        for (int i = 4; i <= n; i++)
        {
            a = (a1 + a2 + a3) % 10007;
            a1 = a2;
            a2 = a3;
            a3 = a;
        }
        Console.WriteLine(a3);
    }
}
