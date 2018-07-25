// detail: https://atcoder.jp/contests/wupc2012/submissions/2904290
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((int)(new DateTime(2012, b[0], b[1]) - new DateTime(2012, a[0], a[1])).TotalDays);
    }
}
