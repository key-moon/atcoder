// detail: https://atcoder.jp/contests/indeednow-qualb/submissions/2284456
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        Console.WriteLine(1 + Console.ReadLine().Split().Select(int.Parse).Zip(Console.ReadLine().Split().Select(int.Parse), (x, y) => Abs(x - y)).Sum());
    }
}
