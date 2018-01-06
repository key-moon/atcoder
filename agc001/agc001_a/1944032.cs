// detail: https://atcoder.jp/contests/agc001/submissions/1944032
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).Where((_, index) => index % 2 == 0).Sum());
    }
}
