// detail: https://atcoder.jp/contests/nikkei2019-final/submissions/6389727
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
        var nmk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(int.Parse).ToList();
        var b = Console.ReadLine().Split().Select(int.Parse).ToList();
        var diff = a.Zip(b, (x, y) => x - y).FirstOrDefault(x => x != 0);
        Console.WriteLine(
            nmk[0] < nmk[1] ? "X" :
            nmk[0] > nmk[1] ? "Y" : 
            diff < 0 ? "X" :
            diff > 0 ? "Y" : 
            "Same");
    }
}
