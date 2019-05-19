// detail: https://atcoder.jp/contests/abc126/submissions/5466326
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
        var mk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var m = mk[0];
        var k = mk[1];
        if (m == 1)
        {
            if (k == 0)
            {
                Console.WriteLine("0 0 1 1");
            }
            else
            {
                Console.WriteLine(-1);
            }
            return;
        }
        if (k >= 1 << m)
        {
            Console.WriteLine(-1);
            return;
        }
        var v = Enumerable.Range(0, (1 << m)).Where(x => x != k).ToArray();
        List<int> res = new List<int>();
        res.Add(k);
        res.AddRange(v);
        res.Add(k);
        res.AddRange(v.Reverse());
        Console.WriteLine(string.Join(" ", res));
    }
}
