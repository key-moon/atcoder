// detail: https://atcoder.jp/contests/nikkei2019-qual/submissions/4114303
using System;
using System.Linq;

class P
{
    static void Main()
    {
        Console.WriteLine(Enumerable.Repeat(0, int.Parse(Console.ReadLine())).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).OrderByDescending(x => x[0] + x[1]).Select((x, y) => new Tuple<long[], int>(x, y)).Aggregate(0L, (x, y) => y.Item2 % 2 == 0 ? x + y.Item1[0] : x - y.Item1[1]));
    }
}
