// detail: https://atcoder.jp/contests/abc002/submissions/1942780
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        char[] aiueo = "aiueo".ToCharArray();
        Console.WriteLine(string.Join("", Console.ReadLine().Where(x => !aiueo.Contains(x)).ToArray()));
    }
}
