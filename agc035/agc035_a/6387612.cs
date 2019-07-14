// detail: https://atcoder.jp/contests/agc035/submissions/6387612
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        Action exit = () => { Console.WriteLine("No"); Environment.Exit(0); };
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach (var item in a)
        {
            if (!dict.ContainsKey(item)) dict.Add(item, 0);
            dict[item]++;
        }

        int ll = dict.First().Key;
        int l = dict.Last().Key;
        int first = ll;
        dict[ll]--;
        dict[l]--;

        if (dict[ll] == 0)
            dict.Remove(ll);

        if (dict[l] == 0)
            dict.Remove(l);
        while (dict.Count > 0)
        {
            var next = l ^ ll;
            if (!dict.ContainsKey(next))
                exit();
            dict[next]--;
            if (dict[next] == 0)
                dict.Remove(next);
            ll = l;
            l = next;
        }
        if (first != (l ^ ll))
            exit();
        Console.WriteLine("Yes");
    }
}
