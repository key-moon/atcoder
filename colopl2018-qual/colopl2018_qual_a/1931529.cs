// detail: https://atcoder.jp/contests/colopl2018-qual/submissions/1931529
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] AB = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string s = Console.ReadLine();
        Console.WriteLine(AB[0] <= s.Length && s.Length <= AB[1] ? "YES" : "NO");
    }
}
