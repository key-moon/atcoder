// detail: https://atcoder.jp/contests/arc083/submissions/5106644
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if (n == 1)
        {
            Console.WriteLine("POSSIBLE");
            return;
        }
        var p = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
        var X = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var childlen = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < p.Length; i++) childlen[p[i]].Add(i + 1);
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        List<int> order = new List<int>();
        while (stack.Count > 0)
        {
            int elem = stack.Pop();
            order.Add(elem);
            foreach (var child in childlen[elem]) stack.Push(child);
        }
        Tuple<int, int>[] bw = new Tuple<int, int>[n];
        foreach (var elem in order.Reverse<int>())
        {
            //Xまで詰めたい
            List<bool> knapsack = new bool[X[elem] + 1].ToList();
            knapsack[0] = true;
            int totalSum = 0;
            foreach (var child in childlen[elem])
            {
                totalSum += bw[child].Item1;
                totalSum += bw[child].Item2;
                for (int i = knapsack.Count - 1; i >= 0; i--)
                {
                    if (!knapsack[i]) continue;
                    knapsack[i] = false;
                    if (i + bw[child].Item1 < knapsack.Count) knapsack[i + bw[child].Item1] = true;
                    if (i + bw[child].Item2 < knapsack.Count) knapsack[i + bw[child].Item2] = true;
                }
            }
            var count = knapsack.LastIndexOf(true);
            if(count == -1)
            {
                Console.WriteLine("IMPOSSIBLE");
                return;
            }
            bw[elem] = new Tuple<int, int>(totalSum - count, X[elem]);
        }
        Console.WriteLine("POSSIBLE");
    }
}
