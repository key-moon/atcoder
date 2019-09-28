// detail: https://atcoder.jp/contests/abc142/submissions/7747649
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        Tuple<int, int>[] keys = new Tuple<int, int>[m];
        long[] curCost = Enumerable.Repeat(1L << 60, 1 << n).ToArray();
        curCost[0] = 0;
        for (int i = 0; i < m; i++)
        {
            var a = int.Parse(Console.ReadLine().Split().First());
            int val = 0;
            foreach (var c in Console.ReadLine().Split().Select(int.Parse).ToArray())
            {
                val |= 1 << (c - 1);
            }
            for (int j = 0; j < curCost.Length; j++)
            {
                curCost[j | val] = Min(curCost[j | val], curCost[j] + a);
            }
        }
        if (curCost.Last() == (1L << 60))
        {
            Console.WriteLine(-1);
            return;
        }
        Console.WriteLine(curCost.Last());
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
