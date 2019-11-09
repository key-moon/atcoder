// detail: https://atcoder.jp/contests/nikkei2019-2-qual/submissions/8355910
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
        //ソートで必要な数を計算+もしN-1だったらswap可能な場所を探す
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var mergedSorted = a.OrderBy(x => x).Zip(b.OrderBy(x => x), (x, y) => new Tuple<int, int>(x, y)).ToArray();
        if (mergedSorted.Any(x => x.Item1 > x.Item2))
        {
            Console.WriteLine("No");
            return;
        }
        if (mergedSorted.Zip(mergedSorted.Skip(1), (x, y) =>
        {
            var fa = x.Item1;
            var fb = x.Item2;
            var sa = y.Item1;
            var sb = y.Item2;
            //swap可能
            return fa <= sb && sa <= fb;
        }).Any(x => x))
        {
            Console.WriteLine("Yes");
            return;
        }
        Dictionary<int, int> adic = a.OrderBy(x => x).Select((x, y) => new Tuple<int, int>(x, y)).ToDictionary(x => x.Item1, x => x.Item2);
        var inita = a.Zip(b, (x, y) => new Tuple<int, int>(x, y)).OrderBy(x => x.Item2).Select(x => adic[x.Item1]).ToArray();
        int pos = 0;
        int count = 0;
        do
        {
            pos = inita[pos];
            count++;
        }
        while (pos != 0) ;
        Console.WriteLine(count == n ? "No" : "Yes");
    }
}
