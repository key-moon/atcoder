// detail: https://atcoder.jp/contests/chokudai_S001/submissions/2095961
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(a.ToList().IndexOf(1) + 1);
    }
}
