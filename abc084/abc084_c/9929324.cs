// detail: https://atcoder.jp/contests/abc084/submissions/9929324
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var stations = Enumerable.Repeat(0, n - 1).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        for (int i = 0; i < n; i++)
        {
            int time = 0;
            foreach (var station in stations.Skip(i))
            {
                time = Max(station[1], time);
                time = ((time + station[2] - 1) / station[2]) * station[2];
                time += station[0];
            }
            Console.WriteLine(time);
        }
    }
}
