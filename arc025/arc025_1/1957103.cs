// detail: https://atcoder.jp/contests/arc025/submissions/1957103
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {   
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).Zip(Console.ReadLine().Split().Select(int.Parse), (x, y) => Math.Max(x, y)).Sum());
    }
}
