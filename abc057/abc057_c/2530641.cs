// detail: https://atcoder.jp/contests/abc057/submissions/2530641
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        int min = 100;
        for (int i = 1; i <= 100000; i++)
        {
            if (n % i != 0) continue;
            min = Min(min, Max(i.ToString().Length, (n / i).ToString().Length));
        }
        Console.WriteLine(min);
    }
}
