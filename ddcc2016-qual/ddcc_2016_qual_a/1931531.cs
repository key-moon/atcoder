// detail: https://atcoder.jp/contests/ddcc2016-qual/submissions/1931531
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] ABC = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((double)ABC[2] * ABC[1] / ABC[0]);
    }
}
