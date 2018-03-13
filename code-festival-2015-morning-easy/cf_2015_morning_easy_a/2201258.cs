// detail: https://atcoder.jp/contests/code-festival-2015-morning-easy/submissions/2201258
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int i = int.Parse(Console.ReadLine());
        int res = 0;
        while (Math.Round(Math.Sqrt(i)) != Math.Sqrt(i))
        {
            i++;
            res++;
        }
        Console.WriteLine(res);
    }
}
