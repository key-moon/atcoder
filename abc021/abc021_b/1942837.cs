// detail: https://atcoder.jp/contests/abc021/submissions/1942837
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        string s = Console.ReadLine();
        Console.ReadLine();
        int[] a = (s + " " +Console.ReadLine()).Split().Select(int.Parse).ToArray();
        foreach (var i in a)
        {
            if(a.Count(x => x == i) != 1)
            {
                Console.WriteLine("NO");
                return;
            }
        }
        Console.WriteLine("YES");
    }
}
