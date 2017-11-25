// detail: https://atcoder.jp/contests/cf17-final-open/submissions/1802989
using System;
using System.Text.RegularExpressions;
class P
{
    static void Main()
    {
        Console.WriteLine(Regex.IsMatch(Console.ReadLine(), "^A?KIHA?BA?RA?$") ? "YES" : "NO");
    }
}
