// detail: https://atcoder.jp/contests/abc042/submissions/1933071
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] NL = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string[] S = new string[NL[0]].Select(_ => Console.ReadLine()).OrderBy(x => x).ToArray();
        string res = "";
        foreach (var s in S)
        {
            res += s;
        }
        Console.WriteLine(res);
    }
}
