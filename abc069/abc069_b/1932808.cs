// detail: https://atcoder.jp/contests/abc069/submissions/1932808
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int[] N = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string s = Console.ReadLine();

        Console.WriteLine($"{s[0]}{s.Length - 2}{s[s.Length - 1]}");
    }
}
