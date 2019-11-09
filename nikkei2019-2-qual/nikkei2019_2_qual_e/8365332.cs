// detail: https://atcoder.jp/contests/nikkei2019-2-qual/submissions/8365332
//#define LOCAL
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Math;   
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
#if LOCAL
        var rng = new Random();
        while (true)
        {
            var k = rng.Next(1, 100000);
            var n = rng.Next(1, 1000000000);
            Solve(k, n);
            Console.WriteLine("end validate");
        }
#else

        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = nk[0];
        long k = nk[1];
        var res = Solve(n, k);
        if (res == null)
        {
            Console.WriteLine(-1);
            return;
        }
        Console.WriteLine(string.Join("
", res.Select(x => $"{x.Item1} {x.Item2} {x.Item3}")));
#endif
    }

    public static Tuple<long, long, long>[] Solve(int n, long k)
    {
        var cands = Enumerable.Range((int)k, 3 * n).Select(x => (long)x).ToArray();
        var prevSum = cands.Take(n * 2).Sum();
        var afterSum = cands.Skip(n * 2).Sum();
        
        //2k <= n + 1であれば合法
        if (prevSum > afterSum)
        {
            if (2 * k <= n + 1) throw new Exception();
            return null;
        } 
        var mother = cands.Skip(n).Take(n).ToArray();

        var a = cands.Take(n / 2).Reverse().Concat(cands.Take(n).Skip(n / 2).Reverse()).ToArray();
        var b = mother.Where(x => x % 2 == 1).Concat(mother.Where(x => x % 2 == 0)).ToArray();
        var c = cands.Skip(n * 2).ToArray();

        var res = a.Concat(b).Concat(c).ToArray();

        if (res.Distinct().Count() != 3 * n)
            throw new Exception();
      
        if (res.Min() != k)
            throw new Exception();

        if (res.Max() != k + 3 * n - 1)
            throw new Exception();

        try
        {
            for (int i = 0; i < n; i++)
                if (a[i] + b[i] > c[i]) throw new Exception();
        }
        catch
        {
            var minstack = new Stack<int>(Enumerable.Range((int)k, n).Reverse());
            return Enumerable.Range(0, n).Select(x => new Tuple<long, long, long>(c[x] - b[x], b[x], c[x])).OrderBy(x => x.Item1)
                .Select(x => new Tuple<long, long, long>(minstack.Pop(), x.Item2, x.Item3)).ToArray();
        }

        return Enumerable.Range(0, n).Select(x => new Tuple<long, long, long>(a[x], b[x], c[x])).ToArray();
    }
}
