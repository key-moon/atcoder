// detail: https://atcoder.jp/contests/arc095/submissions/2349448
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        int last = a.Last();
        double lasthalf = (double)last / 2;
        a = a.Take(a.Length - 1).ToArray();
        double limdef = int.MaxValue;
        int limval = 0;
        foreach (var item in a)
        {
            if (Abs(lasthalf - item) < limdef)
            {
                limdef = Abs(lasthalf - item);
                limval = item;
            }
        }
        Console.WriteLine($"{last} {limval}");
    }
}
