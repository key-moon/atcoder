// detail: https://atcoder.jp/contests/joi2014yo/submissions/6122220
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
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] price = Enumerable.Repeat(0, nm[0]).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        Console.WriteLine(Enumerable.Repeat(0, nm[1]).Select(_ => int.Parse(Console.ReadLine())).Select(x => price.TakeWhile(y => x < y).Count()).GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key + 1);
    }
}
