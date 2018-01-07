// detail: https://atcoder.jp/contests/abc058/submissions/1954309
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        IEnumerable<int> ch = Enumerable.Repeat(int.MaxValue, 26);
        for (int i = 0; i < n; i++)
        {
            int[] p = new int[26];
            foreach (var c in Console.ReadLine())
            {
                p[c - 'a']++;
            }
            ch = ch.Zip(p, (x, y) => Math.Min(x, y));
        }
        string res = "";
        int[] ccc = ch.ToArray();
        for (int i = 0; i < 26; i++)
        {
            res += new string(char.ConvertFromUtf32('a' + i)[0], ccc[i]);
        }
        Console.WriteLine(res);
    }
}
