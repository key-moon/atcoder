// detail: https://atcoder.jp/contests/abc068/submissions/2484986
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] a = { 1, 2, 4, 8, 16, 32, 64 };
        int p = int.Parse(Console.ReadLine());
        Console.WriteLine(a.TakeWhile(x => p >= x).Last());
    }
}
