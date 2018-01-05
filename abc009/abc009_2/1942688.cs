// detail: https://atcoder.jp/contests/abc009/submissions/1942688
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        List<int> p = new List<int>();
        for (int i = 0; i < a; i++)
        {
            int t = int.Parse(Console.ReadLine());
            if (!p.Contains(t)) p.Add(t);
        }
        Console.WriteLine(p.OrderByDescending(x => x).ToArray()[1]);
    }
}
