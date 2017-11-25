// detail: https://atcoder.jp/contests/cf17-final-open/submissions/1803291
using System;
using System.Linq;
class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        int a = s.Count(x => x == 'a');
        int b = s.Count(x => x == 'b');
        int c = s.Count(x => x == 'c');
        Console.WriteLine(Math.Abs(a - b) <= 1 && Math.Abs(b - c) <= 1 && Math.Abs(c - a) <= 1 ? "YES" : "NO");
    }
}
