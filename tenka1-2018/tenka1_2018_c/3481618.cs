// detail: https://atcoder.jp/contests/tenka1-2018/submissions/3481618
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
        int[] a = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).OrderBy(x => x).ToArray();
        int middle = a[n / 2];
        int half = n / 2;
        long sum0 = 0;
        long sum1 = 0;
        for (int i = 0; i < half; i++) sum0 += a[i];
        for (int i = half + (n % 2); i < n; i++) sum1 += a[i];
        long res = (sum1 - sum0) * 2;
        if (n % 2 != 0)
        {
            res -= Min(a[n / 2 + 1] - middle, middle - a[n / 2 - 1]);
        }
        else
        {
            res -= a[n / 2] - a[n / 2 - 1];
        }
        Console.WriteLine(res);
    }
}
