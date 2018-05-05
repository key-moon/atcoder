// detail: https://atcoder.jp/contests/abc096/submissions/2461525
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        long[] abc = Console.ReadLine().Split().Select(long.Parse).ToArray();
        int k = int.Parse(Console.ReadLine()); ;
        long max = abc.Max();
        long pow = max;
        for (int i = 0; i < k; i++)
        {
            pow *= 2;
        }
        Console.WriteLine(abc.Sum() - max + pow);
    }
    
}
