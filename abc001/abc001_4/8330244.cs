// detail: https://atcoder.jp/contests/abc001/submissions/8330244
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        bool[] hasRaining = new bool[24 * 60 + 1/*2400*/ + 1/*番兵*/];
        for (int i = 0; i < n; i++)
        {
            var s = Console.ReadLine().Split('-').Select(
                x => int.Parse(x.Substring(0, 2)) * (60 / 5) + double.Parse(x.Substring(2, 2)) / 5
            ).ToArray();
            var start = (int)Floor(s[0]) * 5;
            var end = (int)Ceiling(s[1]) * 5;
            for (int j = start; j <= end; j++)
                hasRaining[j] = true;
        }
        Func<int, string> formatTime = token => $"{token / 60:00}{token % 60:00}";
        int startInd = -1;
        for (int i = 0; i < hasRaining.Length; i++)
        {
            if (hasRaining[i])
            {
                if (startInd == -1) startInd = i;
            }
            else
            {
                if (startInd != -1)
                {
                    Console.WriteLine($"{formatTime(startInd)}-{formatTime(i - 1)}");
                    startInd = -1;
                }
            }
        }
    }
}
