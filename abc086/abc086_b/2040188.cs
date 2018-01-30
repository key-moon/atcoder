// detail: https://atcoder.jp/contests/abc086/submissions/2040188
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        double a = Math.Sqrt(int.Parse(string.Join("",Console.ReadLine().Split())));
        Console.WriteLine(a % 1 == 0 ? "Yes" : "No");

    }
}
