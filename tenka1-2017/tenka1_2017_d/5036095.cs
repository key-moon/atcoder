// detail: https://atcoder.jp/contests/tenka1-2017/submissions/5036095
using System;
using System.IO;
using System.Linq;
using System.Collections;
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
        int n = nk[0];
        int k = nk[1];
        List<Tuple<int, int>> items = new List<Tuple<int, int>>();
        for (int i = 0; i < n; i++)
        {
            var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            items.Add(new Tuple<int, int>(ab[0], ab[1]));
        }
        long max = 0;
        for (int i = 29; i >= 0; i--)
        {
            long score = 0;

            List<Tuple<int, int>> newItems = new List<Tuple<int, int>>();
            //i桁目を取るか、取らないか それより上の桁の制約は既にない。
            foreach (var item in items)
            {
                if (((item.Item1 >> i) & 1) == 1)
                {
                    if (((k >> i) & 1) == 1) newItems.Add(item);
                }
                else
                {
                    if (((k >> i) & 1) == 1) score += item.Item2;
                    newItems.Add(item);
                }
            }
            items = newItems;
            max = Max(max, score);
        }
        max = Max(max, items.Sum(x => (long)x.Item2));
        Console.WriteLine(max);
    }
}
