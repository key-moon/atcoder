// detail: https://atcoder.jp/contests/abc131/submissions/6065959
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var theoritical = (n - 1) * (n - 2) / 2;
        if (theoritical < k)
        {
            Console.WriteLine(-1);
            return;
        }
        List<Tuple<int, int>> edges = new List<Tuple<int, int>>();
        //ベースとなる木の構築
        edges.AddRange(Enumerable.Range(2, n - 1).Select(x => new Tuple<int, int>(1, x)));
        //辺を引いてペアを殺す
        //辺の集合
        edges.AddRange(
            Enumerable.Range(2, n - 1).SelectMany(x => Enumerable.Range(2, x - 2).Select(y => new Tuple<int, int>(y, x))).Take(theoritical - k)
        );
        Console.WriteLine(edges.Count);
        Console.WriteLine(string.Join("
", edges.Select(x => $"{x.Item1} {x.Item2}")));
    }
}
