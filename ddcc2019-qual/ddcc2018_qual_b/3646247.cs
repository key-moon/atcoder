// detail: https://atcoder.jp/contests/ddcc2019-qual/submissions/3646247
using System;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double half = (double)n / 2;
        int res = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (Abs(half - i) + Abs(half - j) > half + 0.00000001) continue;
                if (Abs(half - i - 1) + Abs(half - j) > half + 0.00000001) continue;
                if (Abs(half - i) + Abs(half - j - 1) > half + 0.00000001) continue;
                if (Abs(half - i - 1) + Abs(half - j - 1) > half + 0.00000001) continue;
                res++;
            }
        }
        Console.WriteLine(res);
    }
}
