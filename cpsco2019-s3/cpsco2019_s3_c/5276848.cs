// detail: https://atcoder.jp/contests/cpsco2019-s3/submissions/5276848
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
        var n = int.Parse(Console.ReadLine());
        int[] imos = new int[1000002];
        for (int i = 0; i < n; i++)
        {
            var st = Console.ReadLine().Split().Select(int.Parse).ToArray();
            imos[st[0]]++;
            imos[st[1]]--;
        }
        int count = 0;
        int current = 0;
        for (int i = 0; i < imos.Length; i++)
        {
            var isNonZero = current != 0;
            current += imos[i];
            if (isNonZero && current == 0) count++;
        }
        Console.WriteLine(count);
    }
}
