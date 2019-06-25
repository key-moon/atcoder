// detail: https://atcoder.jp/contests/joisc2007/submissions/6121729
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
        int[] height = new int[n];
        int[] count = new int[n];
        for (int i = 0; i < n; i++)
        {
            var a = int.Parse(Console.ReadLine());
            height[i] = a;
            int max = 0;
            for (int j = 0; j < i; j++)
                if (height[j] < a)
                    max = Max(max, count[j]);
            count[i] = max + 1;
        }
        Console.WriteLine(count.Max());
    }
}
