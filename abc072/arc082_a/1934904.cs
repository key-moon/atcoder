// detail: https://atcoder.jp/contests/abc072/submissions/1934904
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Dictionary<int, int> dict = new Dictionary<int, int>();

        foreach (var i in a)
        {
            if (!dict.ContainsKey(i - 1)) dict.Add(i - 1, 0);
            if (!dict.ContainsKey(i)) dict.Add(i,0);
            if (!dict.ContainsKey(i + 1)) dict.Add(i + 1, 0);
            dict[i - 1]++;
            dict[i]++;
            dict[i + 1]++;
        }
        Console.WriteLine(dict.Max(x => x.Value));
    }
}
