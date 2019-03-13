// detail: https://atcoder.jp/contests/jag2018summer-day2/submissions/4572506
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        int[] counts = new int[15];
        for (int i = 0; i < 500; i++)
        {
            int current = i;
            int res = 0;
            foreach (var coin in new int[] { 500, 100, 50, 10, 5, 1 })
            {
                res += current / coin;
                current %= coin;
            }
            counts[res]++;
        }
        Console.WriteLine(counts.Take((int)Min(n + 1, 15)).Sum());
    }
}
