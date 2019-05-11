// detail: https://atcoder.jp/contests/diverta2019/submissions/5351265
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Debug = System.Diagnostics.Debug;
using System.Runtime.CompilerServices;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        string[] s = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).ToArray();
        var tailA = s.Count(x => x.Last() == 'A');
        var headB = s.Count(x => x.First() == 'B');
        var res = 0;
        foreach (var item in s)
        {
            for (int i = 0; i < item.Length - 1; i++)
            {
                if (item[i] == 'A' && item[i + 1] == 'B') res++;
            }
        }
        res += Max(0, Min(tailA, headB) - (s.All(x => (x.First() == 'B' && x.Last() == 'A') || (x.First() != 'B' && x.Last() != 'A')) ? 1 : 0));
        Console.WriteLine(res);
    }
}
