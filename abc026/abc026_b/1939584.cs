// detail: https://atcoder.jp/contests/abc026/submissions/1939584
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int n =int.Parse(Console.ReadLine());
        List<int> range = new List<int>();
        for (int i = 0; i < n; i++)
        {
            range.Add(int.Parse(Console.ReadLine()));
        }
        range = range.OrderByDescending(x => x).ToList();
        int res = 0;
        bool b = true;
        foreach (var i in range)
        {
            if (b) res += i * i;
            else res -= i * i;
            b = !b;
        }
        Console.WriteLine(res * Math.PI);

    }
}
