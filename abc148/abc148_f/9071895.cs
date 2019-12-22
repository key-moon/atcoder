// detail: https://atcoder.jp/contests/abc148/submissions/9071895
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var nvu = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nvu[0];
        var v = nvu[1] - 1;
        var u = nvu[2] - 1;

        List<int>[] tree = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            tree[st[0]].Add(st[1]);
            tree[st[1]].Add(st[0]);
        }
        int res = 0;
        var takDists = tree.CalcDists(v);
        var aokDists = tree.CalcDists(u);
        for (int i = 0; i < takDists.Length; i++)
        {
            var tak = takDists[i];
            var aok = aokDists[i];
            if (tak < aok) res = Math.Max(res, aok - 1);
        }
        Console.WriteLine(res);
    }
    
    static int[] CalcDists(this List<int>[] tree, int v)
    {
        var res = new int[tree.Length];
        Stack<int> stack = new Stack<int>();
        stack.Push(v);
        while (stack.Count > 0)
        {
            var elem = stack.Pop();
            foreach (var item in tree[elem])
            {
                if (res[item] != 0 || item == v) continue;
                res[item] = res[elem] + 1;
                stack.Push(item);
            }
        }
        return res;
    }
}
