// detail: https://atcoder.jp/contests/abc079/submissions/1783835
using System;
using System.Collections.Generic;
using System.Linq;
class P
{
    static List<long> lucas = new List<long>();
    static void Main()
    {
        var i = int.Parse(Console.ReadLine());
        lucas.Add(2);
        lucas.Add(1);
        for (int j = 2; j <= i; j++) lucas.Add(lucas[j - 1] + lucas[j - 2]);
        Console.WriteLine(lucas.Last());
    }
}
