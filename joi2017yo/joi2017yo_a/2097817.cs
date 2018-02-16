// detail: https://atcoder.jp/contests/joi2017yo/submissions/2097817
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
        int d = int.Parse(Console.ReadLine());
        int e = int.Parse(Console.ReadLine());

        int res = 0;
        if (a <= 0)
        {
            res += ((-a * c) + d);
            a = 0; 
        }
        res += (b - a) * e;
        Console.WriteLine(res);
    }
}
