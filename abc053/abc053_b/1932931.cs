// detail: https://atcoder.jp/contests/abc053/submissions/1932931
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(s.LastIndexOf('Z') - s.IndexOf('A') + 1);
    }
}
