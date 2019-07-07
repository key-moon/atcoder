// detail: https://atcoder.jp/contests/abc085/submissions/6301646
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;


static class P
{
    static void Main()
    {
        var nh = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //先に全部投げることを考える?
        List<Tuple<int, int>> list = new List<Tuple<int, int>>();
        for (int i = 0; i < nh[0]; i++)
        {
            var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            list.Add(new Tuple<int, int>(ab[0], 0));
            list.Add(new Tuple<int, int>(ab[1], 1));
        }
        var h = nh[1];
        int count = 0;
        foreach (var item in list.OrderByDescending(x => x.Item1))
        {
            if (item.Item2 == 0)
            {
                var c = (h + item.Item1 - 1) / item.Item1;
                count += c;
                h -= c * item.Item1;
            }
            else
            {
                count++;
                h -= item.Item1;
            }
            if (h <= 0) break;
        }
        Console.WriteLine(count);
    }
}
