// detail: https://atcoder.jp/contests/arc102/submissions/3114055
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //mod k
        //a
        //b
        //a
        //a+b=k
        //a+a=k
        //全部同じmod
        //kが3の倍数
        long a = nk[0] / nk[1];
        long b = 0;
        if (nk[1] % 2 == 0)
        {
            b = a;
            if (nk[0] - a * nk[1] >= nk[1] / 2)
            {
                b++;
            }
        }
        Console.WriteLine(a * a * a + b * b * b);
    }
}
