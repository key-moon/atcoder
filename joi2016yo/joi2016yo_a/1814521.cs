// detail: https://atcoder.jp/contests/joi2016yo/submissions/1814521
using System;
using System.Linq;
class P
{
    static void Main()
    {
        Console.WriteLine(new int[4].Select(x => int.Parse(Console.ReadLine())).OrderByDescending(x => x).Where((x,y) => y != 3).Sum() + Math.Max(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
    }
}
