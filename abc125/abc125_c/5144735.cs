// detail: https://atcoder.jp/contests/abc125/submissions/5144735
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var accum = new int[n + 1];
        var accumTail = new int[n + 1];
        for (int i = 0; i < a.Length; i++)
        {
            accum[i + 1] = GCD(accum[i], a[i]);
        }
        int current = 0;
        int max = 0;
        for (int i = a.Length - 1; i >= 0; i--)
        {
            max = Max(max, GCD(accum[i], current));
            current = GCD(current, a[i]);
        }
        Console.WriteLine(max);
    }

    static int GCD(int a, int b)
    {
        while (true)
        {
            if (a > b)
            {
                if (b == 0) return a;
                a %= b;
            }
            else
            {
                if (a == 0) return b;
                b %= a;
            }
        }
    }
}
