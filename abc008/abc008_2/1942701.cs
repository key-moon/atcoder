// detail: https://atcoder.jp/contests/abc008/submissions/1942701
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        Dictionary<string, int> dict = new Dictionary<string, int>();
        for (int i = 0; i < a; i++)
        {
            string s = Console.ReadLine();
            if (!dict.ContainsKey(s)) dict.Add(s, 1);
            else dict[s]++;
        }
        Console.WriteLine(dict.OrderByDescending(x => x.Value).First().Key);
    }
}
