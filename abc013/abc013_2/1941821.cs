// detail: https://atcoder.jp/contests/abc013/submissions/1941821
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int i = int.Parse(Console.ReadLine());
        int j = int.Parse(Console.ReadLine());
        Console.WriteLine(new int[] { Math.Abs(i - j), Math.Abs(i + 10 - j) , Math.Abs(i - j - 10) }.Min());
    }
}
