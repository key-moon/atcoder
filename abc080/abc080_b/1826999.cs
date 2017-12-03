// detail: https://atcoder.jp/contests/abc080/submissions/1826999
using System;
using System.Linq;
class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine((int.Parse(s) % s.Select(x => x - '0').Sum()) == 0? "Yes" : "No");
    }
}
