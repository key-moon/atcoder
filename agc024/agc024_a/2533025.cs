// detail: https://atcoder.jp/contests/agc024/submissions/2533025
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        long[] abck = Console.ReadLine().Split().Select(long.Parse).ToArray();
        Console.WriteLine((abck[1] - abck[0]) * (-1 + (abck[3] % 2) * 2));
    }
}
