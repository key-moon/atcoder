// detail: https://atcoder.jp/contests/code-festival-2016-quala/submissions/1961612
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        int[] A = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
        List<int>[] liked = Enumerable.Range(1, A.Length).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < A.Length; i++)
        {
            liked[A[i]].Add(i);
        }
        int res = 0;
        for (int i = 0; i < A.Length; i++)
        {
            foreach (var item in liked[i])
            {
                if (item > i) break;
                if (liked[item].Contains(i)) res++;
            }
        }
        Console.WriteLine(res);
    }
}
