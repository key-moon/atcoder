// detail: https://atcoder.jp/contests/abc132/submissions/6184922
using System;
using System.Collections.Generic;
static class P
{
    static void Main()
    {
        HashSet<char> set = new HashSet<char>();
        string s = Console.ReadLine();
        for (int i = 0; i < s.Length; i++)
        {
            set.Add(s[i]);
        }
        Console.WriteLine(set.Count == 2 ? "Yes" : "No");
    }
}
