// detail: https://atcoder.jp/contests/abc018/submissions/1932393
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] NST = { int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()) };
        int[] a = NST.OrderByDescending(x => x).ToArray();
        Console.WriteLine(a.ToList().IndexOf(NST[0]) + 1);
        Console.WriteLine(a.ToList().IndexOf(NST[1]) + 1);
        Console.WriteLine(a.ToList().IndexOf(NST[2]) + 1);
    }
}
