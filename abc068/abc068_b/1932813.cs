// detail: https://atcoder.jp/contests/abc068/submissions/1932813
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int[] N = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int i = int.Parse(Console.ReadLine());

        Console.WriteLine(new int[] { 1, 2, 4, 8, 16, 32, 64 }.Where(x => x <= i).Max());
    }
}
