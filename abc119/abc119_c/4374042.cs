// detail: https://atcoder.jp/contests/abc119/submissions/4374042
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;


class P
{
    static void Main()
    {
        var nabc = Console.ReadLine().Split().Select(int.Parse).ToList();
        var l = Enumerable.Repeat(0, nabc[0]).Select(_ => int.Parse(Console.ReadLine())).ToList();
        var min = int.MaxValue;
        for (int i = 0; i < 1 << (nabc[0] * 2); i++)
        {
            int mp = 0;
            int a = 0;
            int b = 0;
            int c = 0;
            for (int j = 0; j < nabc[0]; j++)
            {
                var state = i >> (j * 2) & 3;
                if (state == 1)
                {
                    if (a != 0) mp += 10;
                    a += l[j];
                }
                if (state == 2)
                {
                    if (b != 0) mp += 10;
                    b += l[j];
                }
                if (state == 3)
                {
                    if (c != 0) mp += 10;
                    c += l[j];
                }
            }
            if (a == 0 || b == 0 || c == 0) continue;
            mp += Abs(nabc[1] - a);
            mp += Abs(nabc[2] - b);
            mp += Abs(nabc[3] - c);
            min = Min(min, mp);
        }
        Console.WriteLine(min);
    }
}
