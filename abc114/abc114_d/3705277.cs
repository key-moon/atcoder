// detail: https://atcoder.jp/contests/abc114/submissions/3705277
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
        //3*5*5
        //15*5
        //3*25
        //75
        int n = int.Parse(Console.ReadLine());
        int[] count = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            var facs = factors(i);
            foreach (var fac in facs)
            {
                count[fac]++;
            }
        }
        int count2 = 0;
        int count4 = 0;
        int count14 = 0;
        int count24 = 0;
        int count74 = 0;
        foreach (var c in count)
        {
            if (74 <= c) count74++;
            if (24 <= c) count24++;
            if (14 <= c) count14++;
            if (4 <= c) count4++;
            if (2 <= c) count2++;
        }
        Console.WriteLine((count2 - 2) * (count4) * (count4 - 1) / 2 + count14 * (count4 - 1) + count24 * (count2 - 1) + count74);
    }
    static int[] factors(int n)
    {
        int i = 2;
        List<int> res = new List<int>();
        while (i * i <= n)
        {
            if (n % i == 0)
            {
                res.Add(i);
                n /= i;
            }
            else
            {
                i++;
            }
        }
        if (n != 1) res.Add(n);
        return res.ToArray();
    }
}
