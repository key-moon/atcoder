// detail: https://atcoder.jp/contests/abc085/submissions/1947028
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        //int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //Console.WriteLine(Console.ReadLine().Replace("2017", "2018"));
        List<int> mochi = new List<int>();
        for (int i = 0; i < n; i++)
        {
            mochi.Add(int.Parse(Console.ReadLine()));
        }
        Console.WriteLine(mochi.Distinct().Count());
    }
}
