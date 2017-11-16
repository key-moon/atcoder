// detail: https://atcoder.jp/contests/abc077/submissions/1778620
using System;
using System.Linq;
class P
{
    static void Main(string[] args)
    {
        var i = string.Join("", Console.ReadLine().Reverse());
        Console.WriteLine(i == Console.ReadLine() ? "YES" : "NO");
    }
}
