// detail: https://atcoder.jp/contests/abc142/submissions/7744307
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
        var a = NextLong;
        var b = NextLong;
        var gcd = GCD(a, b);
        long i = 2;
        int res = 1;
        var sqrt = (int)Ceiling(Sqrt(gcd));
        while (i <= sqrt)
        {
            if (gcd % i == 0)
            {
                res++;
                while (gcd % i == 0) gcd /= i;
            }
            i++;
        }
        if (gcd != 1) res++;
        Console.WriteLine(res);
    }

    static long GCD(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            a %= b;
            if (a == 0) return b;
            b %= a;
        }
    }

    static long NextLong
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            long res = 0;
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
