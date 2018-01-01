// detail: https://atcoder.jp/contests/abc082/submissions/1932734
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        char[] s = Console.ReadLine().OrderBy(x => x).ToArray();
        char[] t = Console.ReadLine().OrderByDescending(x => x).ToArray();
        int comp = string.Join("", s).CompareTo(string.Join("", t));
        Console.WriteLine(comp < 0 ? "Yes" : "No");
    }
}
