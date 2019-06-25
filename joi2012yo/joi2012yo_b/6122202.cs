// detail: https://atcoder.jp/contests/joi2012yo/submissions/6122202
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
        int n = int.Parse(Console.ReadLine());
        int[] point = new int[n];
        for (int i = 0; i < n * (n - 1) / 2; i++)
        {
            var ab = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            if (ab[2] > ab[3])
                point[ab[0]] += 3;
            else if (ab[2] < ab[3])
                point[ab[1]] += 3;
            else
            {
                point[ab[0]] += 1;
                point[ab[1]] += 1;
            }
        }
        int rank = 1;
        Console.WriteLine(string.Join("
", point.Select((elem, Index) => new { elem, Index }).GroupBy(x => x.elem).OrderByDescending(x => x.Key).SelectMany(x => { var tmp = x.Select(y => new { Rank = rank, y.Index }).ToArray(); rank += x.Count(); return tmp; }).OrderBy(x => x.Index).Select(x => x.Rank)));
    }
}
