// detail: https://atcoder.jp/contests/arc011/submissions/5316138
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var fl = Console.ReadLine().Split();
        int n = int.Parse(Console.ReadLine());
        var words = fl.Concat(Enumerable.Repeat(0, n).Select(_ => Console.ReadLine())).ToArray();
        int[] distance = Enumerable.Repeat(int.MaxValue / 2, words.Length).ToArray();
        int[] from = Enumerable.Repeat(-1, words.Length).ToArray();
        distance[0] = 0;
        List<int> frontInd = new List<int>() { 0 };
        for (int iter = 1; ; iter++)
        {
            if (frontInd.Count == 0) break;
            List<int> nextFrontWords = new List<int>();
            foreach (var ind in frontInd)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (distance[i] <= iter) continue;
                    if (words[ind].Zip(words[i], (x, y) => x != y).Count(x => x) > 1) continue;
                    from[i] = ind;
                    distance[i] = iter;
                    nextFrontWords.Add(i);
                }
            }
            frontInd = nextFrontWords;
        }
        int ptr = from[1];
        List<int> path = new List<int>() { 1, ptr };
        while (ptr >= 0) path.Add(ptr = from[ptr]);
        Console.WriteLine(path.Count - 3);
        if(path.Count >= 3) Console.WriteLine(string.Join("
", path.Reverse<int>().Skip(1).Select(x => words[x])));
    }
}
