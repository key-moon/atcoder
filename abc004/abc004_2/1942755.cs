// detail: https://atcoder.jp/contests/abc004/submissions/1942755
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        List<string> s = new List<string>();
        for (int i = 0; i < 4; i++) s.Add(string.Join("",Console.ReadLine().Reverse().ToArray()));
        s.Reverse();
        Console.WriteLine(string.Join("
",s));
    }
}
