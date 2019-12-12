// detail: https://atcoder.jp/contests/joi2020yo2/submissions/8922914
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    static int[] table;
    static P()
    {
        table = Enumerable.Repeat(1, 1000001).ToArray();
        for (int i = 1; i < table.Length; i++)
        {
            var next = i + i.ToString().Sum(x => x - '0');
            if (table.Length <= next) continue;
            table[next] += table[i];
        }
    }

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(table[n]);
    }
}
