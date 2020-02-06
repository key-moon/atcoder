// detail: https://atcoder.jp/contests/diverta2019-2/submissions/9923225
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToArray();
        var plusCore = a.First();
        var minusCore = a.Last();
        var aWithOutCore = a.Skip(1).Take(n - 2);
        var plus = aWithOutCore.TakeWhile(x => 0 < x).ToArray();
        var minus = aWithOutCore.SkipWhile(x => 0 < x).ToArray();

        List<string> op = new List<string>();
        //マイナスを作る
        foreach (var item in minus)
        {
            op.Add($"{plusCore} {item}");
            plusCore -= item;
        }
        //プラスを作る
        foreach (var item in plus)
        {
            op.Add($"{minusCore} {item}");
            minusCore -= item;
        }
        op.Add($"{plusCore} {minusCore}");
        Console.WriteLine(plusCore - minusCore);
        Console.WriteLine(string.Join("
", op));
    }
}
