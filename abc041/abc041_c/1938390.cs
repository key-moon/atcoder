// detail: https://atcoder.jp/contests/abc041/submissions/1938390
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        Console.WriteLine(string.Join("
", Console.ReadLine().Split().Select((x, y) => new int[] { y, int.Parse(x) }).ToDictionary(x => x[0], x => x[1]).OrderByDescending(x => x.Value).Select(x => x.Key + 1).ToArray()));
    }
}
