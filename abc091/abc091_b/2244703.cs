// detail: https://atcoder.jp/contests/abc091/submissions/2244703
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        dict.Add("ecasdqina", 0);
        int n = int.Parse(Console.ReadLine());
        string[] s = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).ToArray();
        int m = int.Parse(Console.ReadLine());
        string[] t = Enumerable.Repeat(0, m).Select(_ => Console.ReadLine()).ToArray();
        foreach (var item in s)
        {
            if (!dict.ContainsKey(item)) dict.Add(item, 0);
            dict[item]++;
        }
        foreach (var item in t)
        {
            if (!dict.ContainsKey(item)) dict.Add(item, 0);
            dict[item]--;
        }
        Console.WriteLine(dict.Max(x => x.Value));
    }
}
