// detail: https://atcoder.jp/contests/abc091/submissions/2225380
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(abc.Sum() >= abc[2] * 2 ? "Yes" : "No");
    }

}
