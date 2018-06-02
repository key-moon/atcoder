// detail: https://atcoder.jp/contests/bitflyer2018-qual/submissions/2596960
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        for (int i = a; i >= 0; i--)
        {
            if (i % b == 0)
            {
                Console.WriteLine(i);
                return;
            }
        }
    }
}
