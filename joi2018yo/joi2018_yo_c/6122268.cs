// detail: https://atcoder.jp/contests/joi2018yo/submissions/6122268
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
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var map = Enumerable.Repeat(0, hw[0]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        long min = long.MaxValue;
        for (int i = 0; i < hw[0]; i++)
        {
            for (int j = 0; j < hw[1]; j++)
            {
                long sum = 0;
                for (int k = 0; k < hw[0]; k++)
                {
                    for (int l = 0; l < hw[1]; l++)
                    {
                        sum += map[k][l] * Min(Abs(i - k), Abs(j - l));
                    }
                }
                min = Min(min, sum);
            }
        }
        Console.WriteLine(min);
    }
}
