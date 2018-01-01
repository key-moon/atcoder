// detail: https://atcoder.jp/contests/abc044/submissions/1933049
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int[] NK = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string w = Console.ReadLine();
        int[] ch = new int[26];
        foreach (var c in w)
        {
            ch[c - 'a']++;
        }
        Console.WriteLine(ch.Count(x => x % 2 == 1) == 0 ? "Yes" : "No");
    }
}
