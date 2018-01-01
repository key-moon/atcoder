// detail: https://atcoder.jp/contests/abc082/submissions/1933135
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Dictionary<int, int> count = new Dictionary<int, int>();
        foreach (var i in a)
        {
            if (count.ContainsKey(i))
            {
                count[i]++;
            }
            else
            {
                count.Add(i, 1);
            }
        }
        long res = 0;
        foreach (var i in count)
        {
            if (i.Key > i.Value)
            {
                res += i.Value;
            }
            else
            {
                res += i.Value - i.Key;
            }
        }
        Console.WriteLine(res);
    }
}
