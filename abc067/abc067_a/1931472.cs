// detail: https://atcoder.jp/contests/abc067/submissions/1931472
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((s[0] % 3) * (s[1] % 3) * ((s[0] + s[1]) % 3) == 0 ? "Possible" : "Impossible");
    }
}
