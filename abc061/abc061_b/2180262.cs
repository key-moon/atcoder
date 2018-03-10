// detail: https://atcoder.jp/contests/abc061/submissions/2180262
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] c = new int[a[0]];
        for (int i = 0; i < a[1]; i++)
        {
            int[] xy = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            c[xy[0]]++;
            c[xy[1]]++;
        }
        Console.WriteLine(string.Join("
",c));
    }
}
