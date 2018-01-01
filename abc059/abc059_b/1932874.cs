// detail: https://atcoder.jp/contests/abc059/submissions/1932874
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int[] NMA = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int a = string.Compare(Console.ReadLine().PadLeft(101,'0'), Console.ReadLine().PadLeft(101, '0'));
        
        Console.WriteLine(a > 0 ? "GREATER" : (a < 0 ? "LESS" : "EQUAL"));
    }
}
