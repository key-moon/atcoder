// detail: https://atcoder.jp/contests/agc010/submissions/1943513
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int oddcount = a.Count(x => x % 2 == 1);
        if (oddcount % 2 == 0)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}
