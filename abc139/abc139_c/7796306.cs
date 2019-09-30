// detail: https://atcoder.jp/contests/abc139/submissions/7796306
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        int n = NextInt;
        int last = 0;
        int cur = 0;
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            var h = NextInt;
            if (last >= h)
            {
                cur++;
                max = Max(max, cur);
            }
            else
            {
                cur = 0;
            }
            last = h;
        }
        Console.WriteLine(max);
    }

    static readonly TextReader In = Console.In;
    static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0;
            int next = In.Read();
            while (48 <= next && next <= 57)
            {
                res = res * 10 + next - 48;
                next = In.Read();
            }
            return res;
        }
    }
}
