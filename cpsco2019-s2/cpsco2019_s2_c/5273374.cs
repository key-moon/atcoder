// detail: https://atcoder.jp/contests/cpsco2019-s2/submissions/5273374
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        List<long> spot = new List<long>();
        var k = Console.ReadLine().Split().Select(int.Parse).Last();
        string s = Console.ReadLine();
        int curScore = 0;
        for (int i = 0; i < s.Length - 1; i++)
        {
            if (s[i] == '(') curScore += 1;
            else curScore -= 1;
            spot.Add(curScore);
        }
        Console.WriteLine(spot.OrderByDescending(x => x).Take(k).Sum());
    }
}
