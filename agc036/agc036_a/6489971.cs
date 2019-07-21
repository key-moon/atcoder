// detail: https://atcoder.jp/contests/agc036/submissions/6489971
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    const long MAX = 1000000000;
    static void Main()
    {
        long s = long.Parse(Console.ReadLine());
        if (s == 1000000000000000000)
        {
            Console.WriteLine($"0 0 0 {MAX} {MAX} 0");
            return;
        }
        Console.WriteLine($"1 0 0 {MAX} {s / MAX + 1} {s % MAX}");
    }
}
