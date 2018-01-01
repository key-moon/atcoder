// detail: https://atcoder.jp/contests/abc026/submissions/1932329
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine((a / 2) * (a - (a / 2)));
    }
}
