// detail: https://atcoder.jp/contests/soundhound2018-summer-qual/submissions/2801774
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        if(ab[0] * ab[1] == 15)
        {
            Console.WriteLine("*");
        }
        else if (ab[0] + ab[1] == 15)
        {
            Console.WriteLine("+");
        }
        else
        {
            Console.WriteLine("x");
        }
    }
}
