// detail: https://atcoder.jp/contests/abc042/submissions/1920063
using System; 
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(s.Count(x => x == '5') == 2 && s.Contains('7') ? "YES" : "NO");
    }
}
