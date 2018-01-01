// detail: https://atcoder.jp/contests/abc081/submissions/1933852
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] NK = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] A = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach (var i in A)
        {
            if (!dict.ContainsKey(i)) dict.Add(i, 0);
            dict[i]++;
        }
        int[] value = dict.Values.ToArray().OrderBy(x => x).ToArray();
        if (value.Length <= NK[1])
        {
            Console.WriteLine(0);
        }
        else
        {
            Console.WriteLine(value.Take(value.Length - NK[1]).Sum());
        }
    }
}
