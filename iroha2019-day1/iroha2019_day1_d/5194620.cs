// detail: https://atcoder.jp/contests/iroha2019-day1/submissions/5194620
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

static class P
{
    static void Main()
    {
        var nxy = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToArray();
        var ta = nxy[1] + a.Where((x, y) => y % 2 == 0).Sum();
        var ao = nxy[2] + a.Where((x, y) => y % 2 == 1).Sum();
        Console.WriteLine(ta > ao ? "Takahashi" : ta < ao ? "Aoki" : "Draw");
    }
}
