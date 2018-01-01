// detail: https://atcoder.jp/contests/abc058/submissions/1932879
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int[] NMA = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string s = Console.ReadLine();
        string t = Console.ReadLine();
        string res = "";
        for (int i = 0; i < t.Length; i++)
        {
            res += $"{s[i]}{t[i]}";
        }
        if (s.Length != t.Length) res += s[s.Length - 1];
        Console.WriteLine(res);
    }
}
