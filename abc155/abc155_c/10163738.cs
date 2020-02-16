// detail: https://atcoder.jp/contests/abc155/submissions/10163738
using System;
using System.Linq;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(string.Join("
", Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).GroupBy(x => x).GroupBy(x => x.Count()).OrderByDescending(x => x.Key).First().Select(x => x.Key).OrderBy(x => x, StringComparer.OrdinalIgnoreCase)));
    }
}
