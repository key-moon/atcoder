// detail: https://atcoder.jp/contests/kupc2017/submissions/2283438
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nst = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int count = 0;
        while (nst[2] != 0)
        {
            if (nst[1] == nst[2])
            {
                Console.WriteLine(count);
                return;
            }
            nst[2] >>= 1;
            count++;
        }
        Console.WriteLine("-1");
    }
}
