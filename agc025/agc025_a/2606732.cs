// detail: https://atcoder.jp/contests/agc025/submissions/2606732
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int min = int.MaxValue;
        for (int i = 1; i <= n - 1; i++)
        {
            int sum = i.ToString().Select(x => x - '0').Sum() + (n - i).ToString().Select(x => x - '0').Sum();
            min = Min(min, sum);
        }
        Console.WriteLine(min);
    }
}
