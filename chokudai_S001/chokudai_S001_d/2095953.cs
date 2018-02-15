// detail: https://atcoder.jp/contests/chokudai_S001/submissions/2095953
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        Console.WriteLine(string.Join(" ",a));
    }
}
