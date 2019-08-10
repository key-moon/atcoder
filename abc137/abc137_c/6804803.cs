// detail: https://atcoder.jp/contests/abc137/submissions/6804803
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
        Dictionary<string, int> counts = new Dictionary<string, int>();
        long res = 0;
        for (int i = 0; i < n; i++)
        {
            var str = string.Join("", Console.ReadLine().OrderBy(x => x));
            if (!counts.ContainsKey(str)) counts.Add(str, 0);
            res += counts[str];
            counts[str]++;
        }
        Console.WriteLine(res);
    }
}
