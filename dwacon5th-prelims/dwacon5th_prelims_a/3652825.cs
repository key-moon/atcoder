// detail: https://atcoder.jp/contests/dwacon5th-prelims/submissions/3652825
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
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var ave = a.Average();
        double min = int.MaxValue;
        int mincount = -1;
        for (int i = 0; i < a.Length; i++)
        {
            if (Abs(ave - a[i]) < min)
            {
                min = Abs(ave - a[i]);
                mincount = i;
            }
        }
        Console.WriteLine(mincount);
    }
}
