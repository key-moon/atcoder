// detail: https://atcoder.jp/contests/joi2019yo/submissions/6122133
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;


static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var X = Console.ReadLine().Split().Select(int.Parse).ToList();
        X.Add(2020);
        int.Parse(Console.ReadLine());
        foreach (var operation in Console.ReadLine().Split().Select(x => int.Parse(x) - 1))
            if (X[operation] + 1 < X[operation + 1]) X[operation]++;
        Console.WriteLine(string.Join("
", X.Take(n)));
    }
}
