// detail: https://atcoder.jp/contests/abc149/submissions/9210573
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
    public static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var abk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var r = abk[0];
        var s = abk[1];
        var p = abk[2];
        long res = 0;
        string hands = Console.ReadLine();
        for (int mod = 0; mod < k; mod++)
        {
            char last = '_';
            for (int i = mod; i < n; i += k)
            {
                if (last == hands[i])
                {
                    last = '_';
                    continue;
                }
                switch (hands[i])
                {
                    case 'r':
                        res += p;
                        break;
                    case 'p':
                        res += s;
                        break;
                    case 's':
                        res += r;
                        break;
                    default:
                        break;
                }
                last = hands[i];
            }
        }
        Console.WriteLine(res);
    }
}
