// detail: https://atcoder.jp/contests/arc006/submissions/5313512
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var list = new List<int>() { int.Parse(Console.ReadLine()) };
        for (int i = 1; i < n; i++)
        {
            var w = int.Parse(Console.ReadLine());
            var ind = list.BinarySearch(w);
            if (ind < 0) ind = ~ind;
            if (ind == list.Count) list.Add(w);
            else list[ind] = w;
            list.Sort();
        }
        Console.WriteLine(list.Count);
    }
}
