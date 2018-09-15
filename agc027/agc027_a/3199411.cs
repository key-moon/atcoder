// detail: https://atcoder.jp/contests/agc027/submissions/3199411
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
        int[] nx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int x = nx[1];
        int[] a = Console.ReadLine().Split().Select(int.Parse).OrderBy(p => p).ToArray();
        int count = 0;
        for (int i = 0; i < a.Length; i++)
        {
            x -= a[i];
            if (x < 0)
            {
                Console.WriteLine(count);
                return;
            }
            else
            {
                count++;
            }
        }
        if (x > 0) count--;
        Console.WriteLine(count);
    }
}
