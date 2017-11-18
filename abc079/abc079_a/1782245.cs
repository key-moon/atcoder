// detail: https://atcoder.jp/contests/abc079/submissions/1782245
using System;
class P
{
    static void Main()
    {
        var i = Console.ReadLine();
        Console.WriteLine(i[1] == i[2] && (i[0] == i[1] || i[2] == i[3]) ? "Yes" : "No" );
    }
}
