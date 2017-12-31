// detail: https://atcoder.jp/contests/abc046/submissions/1931397
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<int> i = new List<int>();
        foreach (var item in a)
        {
            if (!i.Contains(item)) i.Add(item);
        }
        Console.WriteLine(i.Count);
    }
}
