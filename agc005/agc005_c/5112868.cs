// detail: https://atcoder.jp/contests/agc005/submissions/5112868
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
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using Debug = System.Diagnostics.Debug;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using System.Runtime.CompilerServices;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        int[] counts = new int[n];

        for (int i = 0; i < a.Length; i++) counts[a[i]]++;

        var diameter = a.Max();
        if (diameter == 1 && n > 2) goto impossible;
        if (diameter % 2 == 0)
        {
            if (counts[diameter / 2] != 1) goto impossible;
            counts[diameter / 2] = 0;
        }
        else
        {
            if (counts[(diameter + 1) / 2] != 2) goto impossible;
            counts[(diameter + 1) / 2] = 0;
        }
        for (int i = (diameter + 3) / 2; i <= diameter; i++)
        {
            if (counts[i] < 2) goto impossible;
            counts[i] = 0;
        }
        if (counts.Sum() > 0) goto impossible;
        Console.WriteLine("Possible");
        return;
        impossible:Console.WriteLine("Impossible");
    }
}
