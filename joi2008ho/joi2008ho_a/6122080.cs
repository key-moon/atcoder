// detail: https://atcoder.jp/contests/joi2008ho/submissions/6122080
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
        var n = int.Parse(Console.ReadLine());
        Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
        stack.Push(new Tuple<int, int>(int.Parse(Console.ReadLine()), 1));
        for (int i = 1; i < n; i++)
        {
            var c = int.Parse(Console.ReadLine());
            if ((stack.Peek().Item1 != c) && (i % 2 == 0))
                stack.Push(new Tuple<int, int>(c, 1));
            else
            {
                var count = stack.Pop().Item2;
                if (0 < stack.Count && stack.Peek().Item1 == c)
                    count += stack.Pop().Item2;
                stack.Push(new Tuple<int, int>(c, count + 1));
            }
        }
        Console.WriteLine(stack.Sum(x => x.Item1 == 0 ? x.Item2 : 0));
    }
}
