// detail: https://atcoder.jp/contests/abc107/submissions/5181670
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
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var x = Console.ReadLine().Split().Select(int.Parse).ToList();
        x.Add(0);
        x.Sort();
        int minLength = int.MaxValue;
        int zeroInd = x.BinarySearch(0);
        for (int i = 0; i <= k; i++)
        {
            int lInd = zeroInd - i;
            int rInd = zeroInd + (k - i);
            if (lInd < 0 || n < rInd) continue;
            minLength = Min(minLength, Min(Abs(x[lInd]) * 2 + x[rInd], Abs(x[lInd]) + x[rInd] * 2));
        }
        Console.WriteLine(minLength);
    }
}
