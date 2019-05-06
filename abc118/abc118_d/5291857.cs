// detail: https://atcoder.jp/contests/abc118/submissions/5291857
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
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;

static class P
{
    static void Main()
    {
        var cost = new int[] { 0, 2, 5, 5, 4, 5, 6, 3, 7, 6 };
        var n = Console.ReadLine().Split().Select(int.Parse).First();
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        BigInteger[] largestNumber = Enumerable.Repeat(BigInteger.MinusOne, n + 10).ToArray();
        largestNumber[0] = 0;
        for (int i = 0; i < n; i++)
        {
            if (largestNumber[i] < 0) continue;
            for (int j = 0; j < a.Length; j++) largestNumber[i + cost[a[j]]] = BigInteger.Max(largestNumber[i + cost[a[j]]], largestNumber[i] * 10 + a[j]);
        }
        Console.WriteLine(largestNumber[n]);
    }
}
