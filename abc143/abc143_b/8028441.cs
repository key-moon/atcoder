// detail: https://atcoder.jp/contests/abc143/submissions/8028441
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var d = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var res = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j) continue;
                res += d[i] * d[j];
            }
        }
        Console.WriteLine(res / 2);
    }
}
