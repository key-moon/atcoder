// detail: https://atcoder.jp/contests/arc075/submissions/9912700
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
        int n = int.Parse(Console.ReadLine());
        var score = new bool[10001];
        score[0] = true;
        for (int i = 0; i < n; i++)
        {
            var s = int.Parse(Console.ReadLine());
            for (int j = score.Length - 1; j >= s; j--)
            {
                if (score[j - s]) score[j] = true;
            }
        }
        for (int i = score.Length - 1; i >= 0; i--)
        {
            if (i % 10 != 0 && score[i])
            {
                Console.WriteLine(i);
                return;
            }
        }
        Console.WriteLine(0);
    }
}
