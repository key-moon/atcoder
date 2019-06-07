// detail: https://atcoder.jp/contests/dp/submissions/5814233
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;

static class P
{
    static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var k = nk[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool[] dp = new bool[k + 1];
        for (int i = 0; i < dp.Length; i++) dp[i] = a.Any(x => 0 <= (i - x) && !dp[i - x]);
        Console.WriteLine(dp[k] ? "First" : "Second");
    }
}
