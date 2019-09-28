// detail: https://atcoder.jp/contests/abc142/submissions/7735099
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(a.Count(x => k <= x));
    }

    static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0;
            int next = Console.In.Read();
            int sign = 1;
            while (45 > next || next > 57) next = Console.In.Read();
            if (next == 45) { next = Console.In.Read(); sign = -1; }
            while (48 <= next && next <= 57)
            {
                res = res * 10 + next - 48;
                next = Console.In.Read();
            }
            return res * sign;
        }
    }
}
