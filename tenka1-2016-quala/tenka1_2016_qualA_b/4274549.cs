// detail: https://atcoder.jp/contests/tenka1-2016-quala/submissions/4274549
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
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] parents = Enumerable.Repeat(0, nm[0]).Select((_, index) => index == 0 ? -1 : int.Parse(Console.ReadLine())).ToArray();
        List<int>[] childs = Enumerable.Repeat(0, nm[0]).Select(_ => new List<int>()).ToArray();
        for (int i = 1; i < parents.Length; i++) childs[parents[i]].Add(i);
        
        int[] min = Enumerable.Repeat(int.MaxValue, nm[0]).ToArray();
        for (int i = 0; i < nm[1]; i++)
        {
            int[] bc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int last = bc[0];
            min[last] = bc[1];
            while (parents[last] != -1)
            {
                min[parents[last]] = Min(min[parents[last]], min[last]);
                last = parents[last];
            }
        }
        min[0] = 0;
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        long sum = 0;
        while (stack.Count != 0)
        {
            int elem = stack.Pop();
            foreach (var child in childs[elem])
            {
                sum += min[child] - min[elem];
                stack.Push(child);
            }
        }
        Console.WriteLine(sum);
    }
}
