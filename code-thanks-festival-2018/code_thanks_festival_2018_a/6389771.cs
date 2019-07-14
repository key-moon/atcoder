// detail: https://atcoder.jp/contests/code-thanks-festival-2018/submissions/6389771
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
        var tabcd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var t = tabcd[0];
        var a = tabcd[1];
        var b = tabcd[2];
        var c = tabcd[3];
        var d = tabcd[4];
        Console.WriteLine(
            a + c <= t ? b + d :
            c <= t ? d :
            b <= t ? b :
            0);
    }
}
