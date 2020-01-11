// detail: https://atcoder.jp/contests/dwacon6th-prelims/submissions/9419685
using System;
using System.IO;
using System.Linq;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var sts = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split()).ToArray();
        var x = Console.ReadLine();
        int res = 0;
        foreach (var st in sts)
        {
            var s = st[0];
            var t = int.Parse(st[1]);
            res += t;
            if (s == x) res = 0;
        }
        Console.WriteLine(res);
    }
}
