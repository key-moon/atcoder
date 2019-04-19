// detail: https://atcoder.jp/contests/tdpc/submissions/5028908
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
        int n = int.Parse(Console.ReadLine());
        bool[] points = new bool[100 * 100 + 1];
        points[0] = true;
        foreach (var item in Console.ReadLine().Split().Select(int.Parse)) for (int i = 9900; i >= 0; i--) points[i + item] |= points[i];
        Console.WriteLine(points.Count(x => x));
    }
}
