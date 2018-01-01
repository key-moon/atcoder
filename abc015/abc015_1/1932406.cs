// detail: https://atcoder.jp/contests/abc015/submissions/1932406
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string a = Console.ReadLine();
        string b = Console.ReadLine();
        Console.WriteLine(a.Length < b.Length ? b : a);
    }
}
