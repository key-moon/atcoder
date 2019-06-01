// detail: https://atcoder.jp/contests/m-solutions2019/submissions/5732738
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        //大きいやつは捨てる
        List<int>[] neighbors = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var ab = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            neighbors[ab[0]].Add(ab[1]);
            neighbors[ab[1]].Add(ab[0]);
        }
        var c = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        var res = c.Take(n - 1).Sum();
        Stack<int> numbers = new Stack<int>(c);
        int[] values = new int[n];
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        values[0] = numbers.Pop();
        while (stack.Count > 0)
        {
            var elem = stack.Pop();
            foreach (var neighbor in neighbors[elem])
            {
                if (values[neighbor] != 0) continue;
                values[neighbor] = numbers.Pop();
                stack.Push(neighbor);
            }
        }
        Console.WriteLine(res);
        Console.WriteLine(string.Join(" ", values));
    }
}
