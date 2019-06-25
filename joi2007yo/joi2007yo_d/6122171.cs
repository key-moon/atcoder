// detail: https://atcoder.jp/contests/joi2007yo/submissions/6122171
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


static class P
{
    static int n;
    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        Console.WriteLine(string.Join("
", Enumerable.Repeat(0, int.Parse(Console.ReadLine())).Aggregate(Enumerable.Range(1, n * 2).ToArray(), (x, _) => x.Shuffle(int.Parse(Console.ReadLine())).ToArray())));
    }
    static IEnumerable<T> Shuffle<T>(this IEnumerable<T> a, int k) => k == 0 ? a.Riffle() : a.Cut(k);
    static IEnumerable<T> Cut<T>(this IEnumerable<T> a, int k) => a.Skip(k).Concat(a.Take(k));
    static IEnumerable<T> Riffle<T>(this IEnumerable<T> a) => a.Take(n).Zip(a.Skip(n), (x, y) => Enumerable.Repeat(x, 1).Concat(Enumerable.Repeat(y, 1))).SelectMany(x => x);
    
}
