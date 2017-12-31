// detail: https://atcoder.jp/contests/abc065/submissions/1931469
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(s[2] - s[1] > s[0] ? "dangerous" : (s[2] > s[1] ? "safe" : "delicious"));
    }
}
