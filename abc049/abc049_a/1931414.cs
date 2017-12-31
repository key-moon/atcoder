// detail: https://atcoder.jp/contests/abc049/submissions/1931414
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        char[] c = { 'a', 'e', 'i', 'o', 'u' };
        Console.WriteLine(s.Where(x => !c.Contains(x)).Count() == 0 ? "vowel" : "consonant");
    }
}
