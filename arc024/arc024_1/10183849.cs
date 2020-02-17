// detail: https://atcoder.jp/contests/arc024/submissions/10183849
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

public static class P
{
    public static void Main()
    {
        Console.ReadLine();
        var l = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var r = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Enumerable.Range(10, 31).Select(x => Min(l.Count(y => y == x), r.Count(y => y == x))).Sum());
    }
}
