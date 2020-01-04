// detail: https://atcoder.jp/contests/arc092/submissions/9311948
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(long.Parse).ToList();

        List<int> operation = new List<int>();
        if (a.All(x => x < 0))
        {
            var max = a.Max();
            Console.WriteLine(max);
            int maxInd = a.IndexOf(max);
            for (int i = 0; i < maxInd; i++)
            {
                a.RemoveAt(0);
                operation.Add(0);
            }
            while (1 < a.Count)
            {
                var last = a.Count - 1;
                a.RemoveAt(last);
                operation.Add(last);
            }
            goto end;
        }

        var shouldKeep = Enumerable.Repeat(false, n).ToList();
        var oddSum = a.Where((elem, index) => index % 2 == 1 && 0 <= elem).Sum();
        var evenSum = a.Where((elem, index) => index % 2 == 0 && 0 <= elem).Sum();
        Console.WriteLine(Max(oddSum, evenSum));
        for (int i = (oddSum < evenSum ? 0 : 1); i < n; i += 2)
            if (0 < a[i]) 
                shouldKeep[i] = true;
        while (!shouldKeep[0])
        {
            shouldKeep.RemoveAt(0);
            operation.Add(0);
        }
        while (!shouldKeep.Last())
        {
            var ind = shouldKeep.Count - 1;
            shouldKeep.RemoveAt(ind);
            operation.Add(ind);
        }
        for (int i = 0; i < shouldKeep.Count; i += 2)
        {
            while (!shouldKeep[i])
            {
                shouldKeep.RemoveAt(i + 1);
                shouldKeep.RemoveAt(i - 1);
                operation.Add(i);
            }
        }
        while (1 < shouldKeep.Count)
        {
            shouldKeep.RemoveAt(2);
            shouldKeep.RemoveAt(1);
            operation.Add(1);
        }
        end:;
        Console.WriteLine(operation.Count);
        Console.WriteLine(string.Join("
", operation.Select(x => x + 1)));
    }
}
