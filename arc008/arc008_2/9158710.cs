// detail: https://atcoder.jp/contests/arc008/submissions/9158710
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        string s = Console.ReadLine();
        var t = Console.ReadLine();
        char[] c = new char[26];
        for (int i = 0; i < t.Length; i++) c[t[i] - 'A']++;
        var res = s.GroupBy(x => x).Max(x => c[x.Key - 'A'] == 0 ? 100 : (x.Count() + c[x.Key - 'A'] - 1) / c[x.Key - 'A']);
        Console.WriteLine(res == 100 ? -1 : res);
    }
}
