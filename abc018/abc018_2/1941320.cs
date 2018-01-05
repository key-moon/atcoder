// detail: https://atcoder.jp/contests/abc018/submissions/1941320

using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
            s = s.Substring(0,a[0] - 1) + string.Join("",s.Substring(a[0] - 1,a[1] - a[0] + 1).Reverse().ToArray()) + s.Substring(a[1]);
        }
        Console.WriteLine(s);
    }
}
