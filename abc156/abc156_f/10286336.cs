// detail: https://atcoder.jp/contests/abc156/submissions/10286336
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        //Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var kq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var d = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var k = kq[0];
        var q = kq[1];
        long[] seq = new long[d.Length + 1];
        for (int _ = 0; _ < q; _++)
        {
            var nxm = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var n = nxm[0];
            var X = nxm[1];
            var m = nxm[2];
            seq[0] = 0;
            for (int i = 0; i < d.Length; i++)
            {
                var add = d[i] % m;
                if (add == 0) add = m;
                seq[i + 1] = seq[i] + add;
            }
            var sum = ((n - 1) / d.Length) * seq.Last();
            var remain = seq[(n - 1) % d.Length];
            sum = (X % m) + sum + remain;
            Console.WriteLine(n - 1 - sum / m);
        }
        //Console.Out.Flush();
    }
}
