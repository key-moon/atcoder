// detail: https://atcoder.jp/contests/nikkei2019-final/submissions/4315328
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
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long[] ruiseki = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            ruiseki[i + 1] = ruiseki[i] + a[i];
        }
        for (int i = 0; i < n; i++)
        {
            long max = 0;
            for (int j = i + 1; j <= n; j++)
            {
                max = Max(max, ruiseki[j] - ruiseki[j - i - 1]);
            }
            Console.WriteLine(max);
        }
    }
}
