// detail: https://atcoder.jp/contests/abc052/submissions/2616629
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] abcd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Max(abcd[0] * abcd[1], abcd[2] * abcd[3]));
    }
}
