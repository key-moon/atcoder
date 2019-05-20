// detail: https://atcoder.jp/contests/joi2006yo/submissions/5495068
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int aRes = 0;
        int bRes = 0;
        for (int i = 0; i < n; i++)
        {
            var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (ab[0] > ab[1]) aRes += ab.Sum();
            if (ab[0] < ab[1]) bRes += ab.Sum();
            if (ab[0] == ab[1])
            {
                aRes += ab[0];
                bRes += ab[1];
            }
        }
        Console.WriteLine($"{aRes} {bRes}");
    }
}
