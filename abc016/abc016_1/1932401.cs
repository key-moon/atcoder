// detail: https://atcoder.jp/contests/abc016/submissions/1932401
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(a[0] % a[1] == 0?"YES":"NO");
    }
}
