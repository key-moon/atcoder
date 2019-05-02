// detail: https://atcoder.jp/contests/iroha2019-day2/submissions/5226905
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        Console.WriteLine(string.Join("
", Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).Compress().Select(x => x + 1)));
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<int> Compress<T>(this IEnumerable<T> collection) where T : IComparable<T>
    {
        var tmp = collection.ToArray();
        var ordered = tmp.OrderBy(x => x);
        T last = ordered.First();
        var dict = new Dictionary<T, int>() { { last, 0 } };
        foreach (var item in ordered.Skip(1))
        {
            if (!last.Equals(item)) dict.Add(item, dict.Count);
            last = item;
        }
        for (int i = 0; i < tmp.Length; i++) yield return dict[tmp[i]];
    }
}
