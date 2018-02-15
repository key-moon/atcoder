// detail: https://atcoder.jp/contests/joi2007yo/submissions/2096436
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        Console.WriteLine(string.Join("",Console.ReadLine().Select(x => char.ConvertFromUtf32((x - 'A' + 23) % 26 + 'A')).ToArray()));
    }
}
