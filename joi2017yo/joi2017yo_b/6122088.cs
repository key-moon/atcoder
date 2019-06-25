// detail: https://atcoder.jp/contests/joi2017yo/submissions/6122088
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
        Console.WriteLine(Enumerable.Repeat(0, nm[1]).Select(_ => Max(0, Console.ReadLine().Split().Select(int.Parse).Last() - nm[0])).OrderByDescending(x => x).Skip(1).Sum());
    }
}
