// detail: https://atcoder.jp/contests/abc073/submissions/1914600
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] A = new int[N].Select(x => int.Parse(Console.ReadLine())).ToArray();

        Dictionary<int, int> paper = new Dictionary<int, int>();
        foreach (int num in A)
        {
            if (!paper.ContainsKey(num))
            {
                paper.Add(num, 0);
            }
            paper[num]++;
        }
        Console.WriteLine(paper.Values.Count(x => x % 2 == 1));
    }
}
